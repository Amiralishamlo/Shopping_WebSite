var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();

connection.start();