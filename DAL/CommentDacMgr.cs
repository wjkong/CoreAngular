using Konger.CoreAngular.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Konger.CoreAngular.DAL
{
    public class CommentDacMgr : DataAccessBase
    {
        public bool InsertFeedback(Feedback feedback)
        {
            var success = false;

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConnectionString);

                using (var cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandText = @"INSERT INTO [dbo].[Feedback] ([Type] ,[Url]) VALUES (@Type, @Url)",
                    CommandType = CommandType.Text
                })
                {
                    connection = null;

                    cmd.Parameters.AddWithValue("@Type", feedback.Type);
                    cmd.Parameters.AddWithValue("@Url", feedback.Url);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                success = true;
            }
            finally
            {
                connection?.Dispose();
            }


            return success;
        }

        public bool InsertComment(Feedback feedback)
        {
            var success = false;

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Feedback] ([FullText], [Description], [Url], Type, parentId) VALUES (@FullText, @Description, @Url, @Type, @ParentId)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@FullText", feedback.FullText);
                    cmd.Parameters.AddWithValue("@Description", feedback.Description);
                    cmd.Parameters.AddWithValue("@Url", feedback.Url);
                    cmd.Parameters.AddWithValue("@Type", feedback.Type);
                    cmd.Parameters.AddWithValue("@ParentId", feedback.ParentId);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    success = true;
                }
            }

            return success;
        }

        public List<Feedback> SelectByUrl(Feedback comment)
        {
            var listOfComment = new List<Feedback>();

            using (var connection = new SqlConnection(ConnectionString))
            {

                using (var cmd = new SqlCommand
                {
                    CommandText =
                        @"SELECT Id, Description, CreatedDate, ParentId FROM [Feedback] WHERE URL = @Url AND TYPE = 'COMMENT'",
                    CommandType = CommandType.Text,
                    Connection = connection
                })
                {
                    cmd.Parameters.AddWithValue("@Url", comment.Url);
                    cmd.Connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var comm = new Feedback
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Description = reader["Description"].ToString(),
                                TimeCreated = Convert.ToDateTime(reader["CreatedDate"]),
                                ParentId = Convert.ToInt32(reader["ParentId"])
                            };

                            listOfComment.Add(comm);
                        }
                    }
                }
            }

            return listOfComment;
        }

        public SiteStat SelectSiteStatByUrl(string url)
        {
            var siteStat = new SiteStat();

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = @"DECLARE @totalLike int, @totalDislike int, @totalComment int
                                    SELECT @totalLike = count([Id])
                                    FROM [dbo].[Feedback]
                                    WHERE TYPE = 'LIKE' AND URL = @URL
                                    SELECT @totalDislike = count([Id])
                                    FROM [dbo].[Feedback]
                                    WHERE TYPE = 'DISLIKE' AND URL = @URL
                                    SELECT @totalComment = count([Id])
                                    FROM [dbo].[Feedback]
                                    WHERE TYPE = 'COMMENT' AND URL = @URL

                                    select @totalLike AS totalLike, @totalDislike AS totalDislike, @totalComment AS totalComment
                                ";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;

                    cmd.Parameters.AddWithValue("@Url", url);

                    cmd.Connection.Open();

                    using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            siteStat.TotalLike = Convert.ToInt32(reader["TotalLike"]);
                            siteStat.TotalDislike = Convert.ToInt32(reader["TotalDislike"]);
                            siteStat.TotalComment = Convert.ToInt32(reader["TotalComment"]);
                        }
                    }
                }
            }

            return siteStat;
        }
    }

}
