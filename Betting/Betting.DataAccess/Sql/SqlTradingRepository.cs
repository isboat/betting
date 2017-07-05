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

                var query = this.MakeInsertOrUpdateTournamentQuery(tournament);

                return this.ExecuteNonQuery(query);
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

                var query = this.MakeSearchQuery(searchTags, "tournaments");

                return this.ExecuteDbReader(query, record =>
                {
                    var records = new List<Tournament>();
                    while (record.Read())
                    {
                        records.Add(MakeRecord(record, this.MakeTournament));
                    }

                    return records;
                });
                /*
                 * 
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
                            records.Add(MakeRecord(record, this.MakeTournament));
                        }

                        return records;
                    }
                }
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string AddOrUpdateContextCategory(ContextCategory contextCategory)
        {
            try
            {
                this.logProvider.Info(
                    $"SqlTradingRepository, CreateOrUpdateTournament, id='{contextCategory.Id}', name='{contextCategory.Name}'");

                var query = this.MakeInsertOrUpdateContextCategoryQuery(contextCategory);
                var newId = GenerateNewId();
                query = query.Replace("$NEWID", newId);

                var dbResult = this.ExecuteNonQuery(query);

                return dbResult == 1 ? newId : null;
            }
            catch (Exception ex)
            {
                this.logProvider.Error($"SqlTradingRepository, CreateOrUpdateTournament, id='{contextCategory.Id}', name='{contextCategory.Name}'", ex);
                throw;
            }
        }

        public List<ContextCategory> GetContextCategories(Dictionary<string, string> searchTags)
        {
            try
            {
                //this.logProvider.Info($"SqlTradingRepository, GetContextCategories, tournamentId='{tournamentId}'");

                var query = this.MakeSearchQuery(searchTags, "categories");

                return this.ExecuteDbReader(query, record =>
                {
                    var records = new List<ContextCategory>();
                    while (record.Read())
                    {
                        records.Add(MakeRecord(record, this.MakeContextCategory));
                    }

                    return records;
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string AddOrUpdateContext(Context context)
        {
            try
            {
                this.logProvider.Info(
                    $"SqlTradingRepository, AddOrUpdateContext, id='{context.Id}', name='{context.Label}'");

                var query = this.MakeInsertOrUpdateContextQuery(context);
                var newId = GenerateNewId();
                query = query.Replace("$NEWID", newId);

                var dbResult = this.ExecuteNonQuery(query);

                return dbResult == 1 ? newId : null;
            }
            catch (Exception ex)
            {
                this.logProvider.Error($"SqlTradingRepository, CreateOrUpdateTournament, id='{context.Id}', label='{context.Label}'", ex);
                throw;
            }
        }

        public List<Context> GetContexts(Dictionary<string, string> searchTags)
        {
            try
            {
                //this.logProvider.Info($"SqlTradingRepository, GetContextCategories, tournamentId='{tournamentId}'");

                var query = this.MakeSearchQuery(searchTags, "contexts");

                return this.ExecuteDbReader(query, record =>
                {
                    var records = new List<Context>();
                    while (record.Read())
                    {
                        records.Add(MakeRecord(record, this.MakeContext));
                    }

                    return records;
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Selection> GetSelections(Dictionary<string, string> searchTags)
        {
            try
            {
                //this.logProvider.Info($"SqlTradingRepository, GetContextCategories, tournamentId='{tournamentId}'");

                var query = this.MakeSearchQuery(searchTags, "selections");

                return this.ExecuteDbReader(query, record =>
                {
                    var records = new List<Selection>();
                    while (record.Read())
                    {
                        records.Add(MakeRecord(record, this.MakeSelection));
                    }

                    return records;
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string CreateOrUpdateSelection(Selection selection)
        {
            try
            {
                this.logProvider.Info(
                    $"SqlTradingRepository, CreateOrUpdateSelection, id='{selection.Id}', name='{selection.Label}'");

                var query = this.MakeInsertOrUpdateSelectionQuery(selection);
                var newId = GenerateNewId();
                query = query.Replace("$NEWID", newId);

                var dbResult = this.ExecuteNonQuery(query);

                return dbResult == 1 ? newId : null;
            }
            catch (Exception ex)
            {
                this.logProvider.Error($"SqlTradingRepository, CreateOrUpdateSelection, id='{selection.Id}', label='{selection.Label}'", ex);
                throw;
            }
        }

        private int ExecuteNonQuery(string query)
        {
            using (var connection = new MySqlConnection(this.ConString))
            {
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.CommandType = CommandType.Text;

                    connection.Open();

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        private T ExecuteDbReader<T>(string query, Func<MySqlDataReader, T> func)
        {
            try
            {
                using (var connection = new MySqlConnection(this.ConString))
                {
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;

                        connection.Open();

                        var record = cmd.ExecuteReader();

                        return func(record);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private ContextCategory MakeContextCategory(MySqlDataReader record)
        {
            var cat = new ContextCategory
            {
                Id = record["id"].ToString(),
                TournamentId = record["tid"].ToString(),
                Name = record["name"].ToString(),
                CreatedOn = ToDateTime(record["createdOn"].ToString())
            };

            if (!string.IsNullOrEmpty(record["endedOn"].ToString()))
            {
                cat.EndedOn = ToDateTime(record["endedOn"].ToString());
            }

            return cat;
        }

        private Context MakeContext(MySqlDataReader record)
        {
            var cat = new Context
            {
                Id = record["id"].ToString(),
                CatId = record["catid"].ToString(),
                Label = record["label"].ToString(),
                CreatedOn = ToDateTime(record["createdOn"].ToString())
            };

            if (!string.IsNullOrEmpty(record["endedOn"].ToString()))
            {
                cat.EndedOn = ToDateTime(record["endedOn"].ToString());
            }

            return cat;
        }

        private Selection MakeSelection(MySqlDataReader record)
        {
            var cat = new Selection
            {
                Id = record["id"].ToString(),
                CId = record["cid"].ToString(),
                Label = record["label"].ToString(),
                Price = Convert.ToDecimal(record["label"].ToString()),
                CreatedOn = ToDateTime(record["createdOn"].ToString())
            };

            if (!string.IsNullOrEmpty(record["endedOn"].ToString()))
            {
                cat.EndedOn = ToDateTime(record["endedOn"].ToString());
            }

            return cat;
        }

        private Tournament MakeTournament(MySqlDataReader record)
        {
            var tournament = new Tournament
            {
                Id = record["id"].ToString(),
                Name = record["name"].ToString(),
                CreatedOn = ToDateTime(record["createdOn"].ToString())
            };

            if (!string.IsNullOrEmpty(record["endedOn"].ToString()))
            {
                tournament.EndedOn = ToDateTime(record["endedOn"].ToString());
            }

            return tournament;
        }

        private T MakeRecord<T>(MySqlDataReader record, Func<MySqlDataReader, T> func)
        {
            return func(record);
        }
    }
}
