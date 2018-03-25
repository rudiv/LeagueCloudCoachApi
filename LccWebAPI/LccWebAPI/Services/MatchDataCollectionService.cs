﻿using LccWebAPI.Constants;
using LccWebAPI.Models.DatabaseModels;
using LccWebAPI.Repository.Match;
using LccWebAPI.Repository.Match.Interfaces;
using LccWebAPI.Repository.Summoner;
using LccWebAPI.Utils;
using Microsoft.Extensions.DependencyInjection;
using RiotSharp;
using RiotSharp.Endpoints.LeagueEndpoint;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LccWebAPI.Services
{
    public class MatchDataCollectionService : HostedService
    {
        private readonly IRiotApi _riotApi;
        private readonly ILogging _logging;
        private readonly IThrottledRequestHelper _throttledRequestHelper;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public MatchDataCollectionService(IRiotApi riotApi, ILogging logging
            , IThrottledRequestHelper throttledRequestHelper, IServiceScopeFactory serviceScopeFactory)
        {
            _riotApi = riotApi;
            _serviceScopeFactory = serviceScopeFactory;
            _logging = logging;
            _throttledRequestHelper = throttledRequestHelper;
        }

        int newSummonersAddedToDatabaseTotal = 0;
        int newSummonersAddedThisSession = 0;

        int matchesUpdatedTotal = 0;
        int matchesUpdatedThisSession = 0;
        
        private void PrintSummary()
        {
            Console.WriteLine("###########SUMMARY###########");
            Console.WriteLine("----------Total----------");
            Console.WriteLine(newSummonersAddedToDatabaseTotal + " new summoners added to the database this session.");
            Console.WriteLine(matchesUpdatedTotal + " Matches have been added this session.");
            Console.WriteLine("---------This Run--------");
            Console.WriteLine(newSummonersAddedThisSession + " new summoners added to the database this run.");
            Console.WriteLine(matchesUpdatedThisSession + " Matches updated this run");
            Console.WriteLine("#############################");
        }

        // This task is not optmised in any way and has lots of code duplication
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                _logging.LogEvent("MatchDataCollectionService started.");

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    //using (var matchupInformationRepository = scope.ServiceProvider.GetRequiredService<REPLACED_IMatchupInformationRepository>())
                    //using (var summonerRepository = scope.ServiceProvider.GetRequiredService<REPLACED_ISummonerRepository>())
                    //{
                    //    try
                    //    {
                    //        _logging.LogEvent("Current matches count - " + matchupInformationRepository.GetAllMatchupInformations().Count());
                      
                    //        var challengerPlayers = await _throttledRequestHelper.SendThrottledRequest<League>(async () => await _riotApi.League.GetChallengerLeagueAsync(RiotSharp.Misc.Region.euw, LeagueQueue.RankedSolo));
                    //        var mastersPlayers = await _throttledRequestHelper.SendThrottledRequest<League>(async () => await _riotApi.League.GetMasterLeagueAsync(RiotSharp.Misc.Region.euw, LeagueQueue.RankedSolo));

                    //        IList<LeaguePosition> highEloPlayerEntires = challengerPlayers.Entries.Concat(mastersPlayers.Entries).ToList();

                    //        int totalPlayers = highEloPlayerEntires.Count();
                    //        int currentCount = 0;

                    //        foreach (var highEloPlayer in highEloPlayerEntires)
                    //        {
                    //            _logging.LogEvent(++currentCount + "/" + totalPlayers + " - " + highEloPlayer.PlayerOrTeamName);

                    //            var summoner = await _throttledRequestHelper.SendThrottledRequest<Summoner>(async () => await _riotApi.Summoner.GetSummonerBySummonerIdAsync(RiotSharp.Misc.Region.euw, Convert.ToInt64(highEloPlayer.PlayerOrTeamId)));

                    //            var summonerInDatabase = summonerRepository.GetSummonerByAccountId(summoner.AccountId);
                    //            if (summoner != null && summonerInDatabase == null)
                    //            {
                    //                summonerRepository.InsertSummoner(new LccSummoner(summoner));
                    //                newSummonersAddedToDatabaseTotal++;
                    //                newSummonersAddedThisSession++;

                    //                var matchList = await _throttledRequestHelper.SendThrottledRequest<MatchList>(async () => await _riotApi.Match.GetMatchListAsync(RiotSharp.Misc.Region.euw, summoner.AccountId, null, null, null, null, null, 0, 25));
                    //                if (matchList != null && matchList?.Matches != null)
                    //                {
                    //                    await GetRiotMatchupInformationAndAddIfNotExisting(matchupInformationRepository, matchList, highEloPlayerEntires);
                    //                }
                    //            }
                    //            else
                    //            {
                    //                DateTime lastUpdatedDate = summonerInDatabase.LastUpdated;
                    //                DateTime lastRevisionDateFromRiot = summoner.RevisionDate;

                    //                if (lastRevisionDateFromRiot > lastUpdatedDate)
                    //                {
                    //                    summonerInDatabase.LastUpdated = summoner.RevisionDate;
                    //                    summonerRepository.UpdateSummoner(summonerInDatabase);

                    //                    var newMatches = await _throttledRequestHelper.SendThrottledRequest<MatchList>(async () => await _riotApi.Match.GetMatchListAsync(RiotSharp.Misc.Region.euw, summoner.AccountId, null, null, null, lastUpdatedDate, DateTime.Now, 0, 25));
                    //                    if (newMatches != null && newMatches?.Matches != null)
                    //                    {
                    //                        await GetRiotMatchupInformationAndAddIfNotExisting(matchupInformationRepository, newMatches, highEloPlayerEntires);
                    //                    }
                    //                }
                    //            }

                    //            summonerRepository.Save();
                    //            matchupInformationRepository.Save();
                    //        }
                    //    }
                    //    catch (RiotSharpException e)
                    //    {
                    //        _logging.LogEvent("RiotSharpException encountered - " + e.Message + ".");
                    //        if (e.HttpStatusCode == (HttpStatusCode)429)
                    //        {
                    //            _logging.LogEvent("RateLimitExceeded exception - Sleeping for 50 seconds.");
                    //            await Task.Run(() => Thread.Sleep(50 * 1000));
                    //        }
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        _logging.LogEvent("Exception encountered - " + e.Message + ".");
                    //    }
                    }
                }

            PrintSummary();

            matchesUpdatedThisSession = 0;
            newSummonersAddedThisSession = 0;

            _logging.LogEvent("MatchDataCollectionService finished, will wait 10 minutes and start again.");
            await Task.Run(() => Thread.Sleep(600000));
        }
        
        private async Task GetRiotMatchupInformationAndAddIfNotExisting(REPLACED_IMatchupInformationRepository matchupInformationRepository, MatchList matchlist, IList<LeaguePosition> highEloPlayerEntires)
        {
            foreach (var match in matchlist?.Matches)
            {
                //// If we currently don't have information about this game in our Database
                //if (match.Queue == LeagueQueue.RankedSoloId && matchupInformationRepository.GetMatchupInformationByGameId(match.GameId) == null)
                //{
                //    //Get riots detailed information about this game
                //    // Contains information such as Runes, Masteries, participants 
                //    Match riotMatchInformation = await _throttledRequestHelper.SendThrottledRequest<Match>(async () => await _riotApi.Match.GetMatchAsync(RiotSharp.Misc.Region.euw, match.GameId));

                //    //If we got it successfully and there's participants 
                //    if (riotMatchInformation != null & riotMatchInformation?.Participants != null)
                //    {
                //        var winningTeamId = riotMatchInformation.Teams.Find(x => x.Win == "Win").TeamId;

                //        List<LccMatchupInformationPlayer> winningTeam = new List<LccMatchupInformationPlayer>();
                //        List<LccMatchupInformationPlayer> losingTeam = new List<LccMatchupInformationPlayer>();

                //        foreach (Participant player in riotMatchInformation.Participants)
                //        {
                //            Player matchPlayer = riotMatchInformation.ParticipantIdentities.FirstOrDefault(x => x.ParticipantId == player.ParticipantId).Player;

                //            LccMatchupInformationPlayer lccMatchupInformationPlayer = new LccMatchupInformationPlayer()
                //            {
                //                ChampionId = player.ChampionId,
                //                Lane = player.Timeline.Lane,
                //                AccountId = matchPlayer.AccountId,
                //                SummonerName = matchPlayer.SummonerName
                //            };

                //            if(player.TeamId == winningTeamId)
                //            {
                //                winningTeam.Add(lccMatchupInformationPlayer);
                //            }
                //            else
                //            {
                //                losingTeam.Add(lccMatchupInformationPlayer);
                //            }
                //        }
                        
                //        matchupInformationRepository.InsertMatchupInformation(new LccMatchupInformation(match.GameId,match.Timestamp, winningTeam, losingTeam));

                //        matchesUpdatedTotal++;
                //        matchesUpdatedThisSession++;

                //        _logging.LogEvent("Added new matchup No:" + matchesUpdatedTotal);
                //    }
                //}
            }
        }
    }
}
