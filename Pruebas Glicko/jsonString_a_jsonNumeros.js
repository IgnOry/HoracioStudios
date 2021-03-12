let json = require('./players_file.json');

for(var player in json){
    for(var data in json[player]){
        json[player][data] = parseFloat(json[player][data]);

        //console.log(json[player][data], " ", typeof(json[player][data]));
    }
    //console.log(json[player]);
    //break;
}

var jsonData = JSON.stringify(json, null, 2);

var fs = require('fs');
fs.writeFile('./players_file.json', jsonData, function(err) {
    if (err) {
        console.log(err);
    }
});