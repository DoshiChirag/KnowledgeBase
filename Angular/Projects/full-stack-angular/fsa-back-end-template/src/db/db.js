import { MongoClient } from "mongodb";

const DB_NAME = "my_database";

export const db =  {
    _dbClient: null,
    connect: async function(url) {
        console.log('connecting with mongo client');
        const client = await MongoClient.connect(url, {maxPoolSize:10, useNewUrlParser: true, useUnifiedTopology: true});
        this._dbClient = client;
        console.log('mongo client connected');
    },
    getConnection: function(){
        if(!this._dbClient){
            console.log('You need to call the connect function first');
        }
        else
        {
            console.log('connect function worked');
        }
        return this._dbClient.db(DB_NAME);
    }
}