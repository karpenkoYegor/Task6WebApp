var messageTable;
var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/message").build();

connection.on("newMessage", () => {
    location.reload();
});

function fulfilled() {

}

function rejected() {
    
}

connection.start().then()