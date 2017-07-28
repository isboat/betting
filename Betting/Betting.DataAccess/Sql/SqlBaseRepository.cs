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
                  $"endedOn='{DateTimeToStr(tournament.EndedOn)}' where id = '{tournament.Id}'";

            return query;
        }
        
        protected string MakeInsertOrUpdateContextCategoryQuery(ContextCategory contextCategory)
        {
            var query = string.IsNullOrEmpty(contextCategory.Id)
                ? $"INSERT INTO categories(id, tid, name, createdOn) " +
                  $"VALUES('$NEWID', '{contextCategory.TournamentId}', '{contextCategory.Name}','{DateTimeToStr(contextCategory.CreatedOn)}');"
                : $"UPDATE categories SET name='{contextCategory.Name}', " +
                  $"endedOn='{DateTimeToStr(contextCategory.EndedOn)}' where id = '{contextCategory.Id}'";

            return query;
        }
        
        protected string MakeInsertOrUpdateContextQuery(Context context)
        {
            var query = string.IsNullOrEmpty(context.Id)
                ? $"INSERT INTO contexts(id, catid, label, createdOn) " +
                  $"VALUES('$NEWID', '{context.CatId}', '{context.Label}','{DateTimeToStr(context.CreatedOn)}');"
                : $"UPDATE contexts SET label='{context.Label}', " +
                  $"endedOn='{DateTimeToStr(context.EndedOn)}' where id = '{context.Id}'";

            return query;
        }
        
        protected string MakeInsertOrUpdateTeamQuery(Team team)
        {
            var query = string.IsNullOrEmpty(team.Id)
                ? $"INSERT INTO teams(id, cid, name, description, createdOn) " +
                  $"VALUES('$NEWID', '{team.Cid}', '{team.Name}', '{team.Description}','{DateTimeToStr(team.CreatedOn)}');"
                : $"UPDATE teams SET name='{team.Name}', description='{team.Description}', " +
                  $"endedOn='{DateTimeToStr(team.EndedOn)}' where id = '{team.Id}'";

            return query;
        }
        
        protected string MakeInsertOrUpdateSelectionQuery(Selection sel)
        {
            var query = string.IsNullOrEmpty(sel.Id)
                ? $"INSERT INTO selections(id, cid, label, createdOn, odds ) " +
                  $"VALUES('$NEWID', '{sel.Cid}', '{sel.Label}', '{DateTimeToStr(sel.CreatedOn)}', '{sel.Odds}');"
                : $"UPDATE selections SET label='{sel.Label}', " +
                  $"odds='{sel.Odds}', " +
                  $"endedOn='{DateTimeToStr(sel.EndedOn)}' where id = '{sel.Id}'";

            return query;
        }
        
        protected string MakeDeleteByIdQuery(string id, string table)
        {
            return $"DELETE FROM {table} WHERE id= '{id}';";
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
