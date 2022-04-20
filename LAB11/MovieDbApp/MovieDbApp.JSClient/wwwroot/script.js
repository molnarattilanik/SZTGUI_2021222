let log = console.log;

let actors = [];
let connection;
getData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:53910/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ActorCreated", (user, message) => {
        getData();
    });
    connection.on("ActorDeleted", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        log("SignalR Connected.");
    } catch (err) {
        log(err);
        setTimeout(start, 5000);
    }
};



async function getData() {
    log('getData');
    await fetch('http://localhost:53910/actor')
        .then(x => x.json())
        .then(y => {
            actors = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    actors.forEach(t => {
        document.getElementById('resultarea').innerHTML += "<tr><td>" + t.actorId + `</td><td><input type="text" id="actorname_${t.actorId}" value="${t.actorName}">` + `</td><td><button type="button" onclick="remove(${t.actorId});">Delete</button><button type="button" onclick="update(${t.actorId});">Update</button></td></tr>`;
    });
}

function create() {
    let name = document.getElementById('actorname').value;
    fetch('http://localhost:53910/actor', {
        method: 'POST',
        headers: { 'Content-Type': "application/json" },
        body: JSON.stringify({ actorName: name }),
    })
        .then(response => response)
        .then(data => {
            log("Actor created");
            getData();
        })
        .catch((error) => { log("Error: ", error); });
}

function remove(id) {
    fetch('http://localhost:53910/actor/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': "application/json" },
        body: null,
    })
        .then(response => response)
        .then(data => {
            log("Actor deleted");
            getData();
        })
        .catch((error) => { log("Error: ", error); });
}


function update(id) {
    log("update actor " + id);
    let name = document.getElementById('actorname_'+id).value;
    fetch('http://localhost:53910/actor', {
        method: 'PUT',
        headers: { 'Content-Type': "application/json" },
        body: JSON.stringify({ actorId:id, actorName: name }),
    })
        .then(response => response)
        .then(data => {
            log("Actor created");
            getData();
        })
        .catch((error) => { log("Error: ", error); });
}