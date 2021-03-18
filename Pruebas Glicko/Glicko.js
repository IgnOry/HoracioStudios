function Cvalue(t)
{
    return Math.sqrt((350**2 - 50**2)/t)
}

function newRD(Rdold, c, t){
    val = Math.min(Math.sqrt(RDold**2 + c**2*t), 350)
    if (val < 20) 
        val = 20
    return val
}

function getPlayersForMatch(playerID, data){
    var playerPoints = data[playerID].points;
    var playerRD = data[playerID].deviation;

    var players = [];
    for (let i = 0; i < Object.keys(data).length; i++){
        if(data[i] != data[playerID])
        {
            //Aquí se modifican las condiciones para seleccionar qué rivales son adecuados para enfrentarse al jugador.
            if(data[i].points >= (playerPoints - playerRD) && data[i].points <= (playerPoints + playerRD)){
                players.push(data[i]);
            }
        }
    }

    return players;
}

function g(RD){
    q = 0.0057565;
    return 1/(Math.sqrt((1 + 3*(q**2)*(RD**2))/Math.PI**2));
}

function E(rivalD, playerPoints, rivalPoints){
    elevateG = -g(rivalD)*(playerPoints-rivalPoints)/400;
    return 1/(1+10**elevateG);
}

function calculateD(player, rivals){
    q = 0.0057565;

    let sum = 0;
    for (let i = 0; i < Object.keys(rivals).length; i++){
        sum += g(rivals[i].deviation)**2 * E(rivals[i].deviation, player.points, rivals[i].points) *
        (1 - E(rivals[i].deviation, player.points, rivals[i].points));
    }

    return 1/(q**2 * sum);
}

function getRD(RD, d){
    return Math.sqrt(1/((1/(RD**2))+(1/(d))));
}

function newPoints(player, rivals, results){
    q = 0.0057565;

    let sum = 0;
    for (let i = 0; i < Object.keys(rivals).length; i++){
        sum += g(rivals[i].deviation) * (results[i] - 
            E(rivals[i].deviation, player.points, rivals[i].points));
    }

    let d = calculateD(player, rivals);
    let newRD = getRD(player.deviation, d);

    console.log("Sum: ", sum);
    console.log("D: ", d);

    var add = ((q/(1/(newRD**2) + 1/d)) * sum);
    //Actualizar valores del jugador
    var poi = (player.points + add);

    console.log("Sin sumar: ", add, " typeof: ", typeof(add));
    console.log("Player Points: ", player.points, " typeof: ", typeof(player.points));
    console.log("Tras sumar: ", poi, " typeof: ", typeof(poi));

    return [poi, newRD];
}

function prediction(RD1, RD2, r1, r2){
    let elevateG = -g(Math.sqrt(RD1**2 + RD2**2))*(r1-r2)/400;
    return 1/(1+10**elevateG);
}

function generateGames(player, rivals){
    var playerPoints = player.points;
    var playerRD = player.deviation;

    var results = [];
    for (let i = 0; i < Object.keys(rivals).length; i++){
        var result = prediction(playerRD, rivals[i].deviation, playerPoints, rivals[i].points);
        let match = Math.random();
        if(match < result){
            results.push(1);
        } else {
            results.push(0);
        }
    }

    return results;
}

function getRandom(arr, n) {
    var result = new Array(n),
        len = arr.length,
        taken = new Array(len);
    if (n > len)
        throw new RangeError("getRandom: more elements taken than available");
    while (n--) {
        var x = Math.floor(Math.random() * len);
        result[n] = arr[x in taken ? taken[x] : x];
        taken[x] = --len in taken ? taken[len] : len;
    }
    return result;
}

let dataFile = require('./players_file.json');


var str = JSON.stringify(dataFile, null, 2); // spacing level = 2

//console.log(Cvalue(30))

let playerID = 0;
console.log("OriginalPoints: ", dataFile[playerID].points);
console.log("OtiginalDeviation: ", dataFile[playerID].deviation);

var totalRivals = getPlayersForMatch(playerID, dataFile);

let numMatches = 10;
var rivals = getRandom(totalRivals, numMatches);

var results = generateGames(dataFile[playerID], rivals);
console.log(results);

values = newPoints(dataFile[playerID], rivals, results);
console.log("New Points: ", values[0]);
console.log("New Deviation: ", values[1]);