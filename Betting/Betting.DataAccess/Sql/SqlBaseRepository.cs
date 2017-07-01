using System;
using System.Collections.Generic;
using Betting.Core;
using Betting.DataObjects;

namespace Betting.DataAccess.Sql
{
    public class SqlBaseRepository: DbBaseRepository
    {
        protected readonly string ConString;

        public SqlBaseRepository()
        {
            this.ConString = ConnectionStrings.Sql;
        }
        
        protected string MakeInsertOrUpdateTournamentQuery(Tournament tournament)
        {
            var query = string.IsNullOrEmpty(tournament.Id)
                ? $"INSERT INTO tournaments(id, name, createdOn) VALUES('{GenerateNewId()}','{tournament.Name}','{DateTimeToStr(tournament.CreatedOn)}');"
                : $"UPDATE tournaments SET name='{tournament.Name}', " +
                  $"createdOn='{DateTimeToStr(tournament.CreatedOn)}' " +
                  $"endedOn='{DateTimeToStr(tournament.EndedOn)}' where id = '{tournament.Id}'";

            return query;
        }
        
        protected string MakeInsertOrUpdateContextCategoryQuery(ContextCategory contextCategory)
        {
            var query = string.IsNullOrEmpty(contextCategory.Id)
                ? $"INSERT INTO categories(id, tid, name, createdOn) " +
                  $"VALUES('$NEWID', '{contextCategory.TournamentId}', '{contextCategory.Name}','{DateTimeToStr(contextCategory.CreatedOn)}');"
                : $"UPDATE categories SET name='{contextCategory.Name}', " +
                  $"createdOn='{DateTimeToStr(contextCategory.CreatedOn)}' " +
                  $"endedOn='{DateTimeToStr(contextCategory.EndedOn)}' where id = '{contextCategory.Id}'";

            return query;
        }


        protected string MakeSearchQuery(Dictionary<string, string> searchTags, string table)
        {
            var whereClause = "";

            foreach (var tag in searchTags)
            {
                whereClause += $",{tag.Key}='{tag.Value}'";
            }


            var query = $"SELECT * FROM {table}";

            if (!string.IsNullOrEmpty(whereClause))
            {
                query += $" WHERE {whereClause.TrimStart(',')}";
            }

            return query;
        }

        protected string GenerateNewId()
        {
            var newGuid = Guid.NewGuid().ToString().Replace("-", "");

            var ticks = DateTime.Now.Ticks;

            return newGuid + ticks;
        }
    }
}
