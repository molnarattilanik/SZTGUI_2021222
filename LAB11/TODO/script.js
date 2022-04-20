var log = console.log;

class TodoItem{
    name;
    description;
    value;
    endDate;

    constructor(name, description, value, endDate){
        this.name = name;
        this.description = description;
        this.value = Number(value);
        this.endDate = new Date(endDate);
    }

    toRow(){
        return `<tr><td>${this.name}</td>`+
        `<td>${this.description}</td>`+
        `<td>${this.endDate}</td>`+
        `<td>${this.value}</td>`+
        `<td><button type="button" onclick="remove('${this.name}');">Delete</button></td>`
        +`</tr>`;
    }
}

var todos = [];

function create(){
    todos.push(new TodoItem(
        document.getElementById('name').value,
        document.getElementById('description').value,
        document.getElementById('value').value,
        document.getElementById('enddate').value,
    ));

    display();
}

function display(){
    document.getElementById('tablerows').innerHTML = "";
    todos.forEach(t => {
        document.getElementById('tablerows').innerHTML += t.toRow();
    });
}

function remove(name){
    todos = todos.filter(t => t.name !== name);
    display();
}