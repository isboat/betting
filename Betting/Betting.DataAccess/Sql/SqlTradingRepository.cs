using System;
using System.Collections.Generic;
using System.Data;
using Betting.DataObjects;
using Betting.Interfaces.DataAccess;
using Betting.Interfaces.Logging;
using MySql.Data.MySqlClient;

namespace Betting.DataAccess.Sql
{
    public class SqlTradingRepository: SqlBaseRepository, ITradingRepository
    {
        private readonly ILoggingProvider logProvider;

        public SqlTradingRepository(ILoggingProvider logProvider)
        {
            this.logProvider = logProvider;
        }


        public int CreateOrUpdateTournament(Tournament tournament)
        {
            try
            {
                this.logProvider.Info(
                    $"SqlTradingRepository, CreateOrUpdateTournament, id='{tournament.Id}', name='{tournament.Name}'");

                using (var connection = new MySqlConnection(this.ConString))
                {
                    var query = this.MakeInsertOrUpdateQuery(tournament);

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;

                        connection.Open();

                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                this.logProvider.Error($"SqlTradingRepository, CreateOrUpdateTournament, id='{tournament.Id}', name='{tournament.Name}'", ex);
                throw;
            }
        }

        public List<Tournament> GetTournaments(Dictionary<string, string> searchTags)
        {
            try
            {
                this.logProvider.Info($"SqlTradingRepository, GetTournaments, tagsCount='{searchTags.Count}'");

                using (var connection = new MySqlConnection(this.ConString))
                {
                    var query = this.MakeSearchQuery(searchTags, "tournaments");

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;

                        connection.Open();

                        var record = cmd.ExecuteReader();

                        var records = new List<Tournament>();
                        while (record.Read())
                        {
                            records.Add(MakeRecord(record,this.MakeTournament));
                        }

                        return records;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private Tournament MakeTournament(MySqlDataReader record)
        {
            var tournament = new Tournament
            {
                Id = record["id"].ToString(),
                Name = record["name"].ToString(),
                CreatedOn = ToDateTime(record["createdOn"].ToString())
            };

            if (string.IsNullOrEmpty(record["createdOn"].ToString()))
            {
                tournament.EndedOn = ToDateTime(record["createdOn"].ToString());
            }

            return tournament;
        }

        private T MakeRecord<T>(MySqlDataReader record, Func<MySqlDataReader, T> func)
        {
            return func(record);
        }
    }
}
