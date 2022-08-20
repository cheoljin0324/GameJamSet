const fs = require('fs');
const ws = require('ws');
const wss = new ws.Server({port:3001});

const path = './data.json';

wss.on('listening', () => {
    console.log(`server opened on port ${wss.options.port}`);
});

wss.on('connection', client => {
    console.log("client connect");
    client.on('message', msg => {
        console.log("client onMessage " + msg.toString());
        const file = require('./data.json');
        if(msg.toString() == "req") 
        {
            file.forEach(userData => {
                client.send(JSON.stringify(userData));
                console.log("server send " + JSON.stringify(userData));
            });
            client.send("res");
            console.log("server send " + "res");
            return;
        }
        const data = JSONParse(msg.toString());
        if(data == false) return;
        if((data.n == undefined) || (data.f == undefined)) return;
        if(file.length <= 0)
        {
            file.push(data);
            fs.writeFileSync(path, JSON.stringify(file));
            return;
        }
        let find = false;
        file.forEach((userData, index) => {
            if(userData.n == data.n)
            {
                file[index] = data;
                fs.writeFileSync(path, JSON.stringify(file));
                find = true;
            }
        });
        if(!find)
        {
            file.push(data);
            fs.writeFileSync(path, JSON.stringify(file));
        }
        console.log("server send foreach" + JSON.stringify(file));
    });
});

const JSONParse = stringData => {
    try
    {
        return JSON.parse(stringData);
    }
    catch(err)
    {
        return false;
    }
}
