﻿using BookManagement.Abstraction;
using BookManagement.Abstraction.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Infrastructure.Data.Mongo
{
    public class MongoContext
    {
        public IMongoDatabase Database { get; }

        private readonly string _serverName;
        private readonly string _databaseName;

        private readonly ConventionPack camelConventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
        private readonly ConventionPack ignoreExtraElementsPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
        private readonly ConventionPack ignoreNullsPack = new ConventionPack { new IgnoreIfNullConvention(true) };
        private readonly MongoClient client;
        public string ServerName => _serverName;
        public string DatabaseName => _databaseName;

        public MongoContext(IOptions<AppSettings> config)
        {

            _serverName = config.Value.CommandServerName;
            _databaseName = config.Value.CommandDatabaseName;

            ConventionPack pack = new ConventionPack
            {
                new IgnoreIfNullConvention(true),
                 new IgnoreExtraElementsConvention(true),
                new CamelCaseElementNameConvention()
            };
            ConventionRegistry.Register("defaults", pack, t => true);
            client = new MongoClient(_serverName);
            Database = client.GetDatabase(_databaseName);
        }

        public IMongoCollection<Book> Books => Database.GetCollection<Book>("Books");
        public IMongoCollection<BookLoan> Loans => Database.GetCollection<BookLoan>("Loans");

    }
}
