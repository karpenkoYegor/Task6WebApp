var messageTable;
var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/message").build();


connection.on("newMessage", (data) => {
    var table = document.getElementById("messagesTable");
    //location.reload();
    console.log(1234);
    console.log(data);
    var block = `<div class="accordion-item">
                                <p class="accordion-header" id="flush-heading${data[0]}">
                                    <label class="form-label">От: ${data[1]}</label>
                                    <label class="form-label">Дата отправки: ${data[2]}</label>
                                    <button class="accordion-button btn-secondary collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapse${data[0]}" aria-expanded="false" aria-controls="@("flush-collapse${data[0]}")">
                                        ${data[3]}
                                    </button>
                                </p>
                                <div id="flush-collapse${data[0]}" class="accordion-collapse collapse" aria-labelledby="flush-headingOne" data-bs-parent="#accordionFlushExample">
                                    <div class="accordion-body">${data[4]}</div>
                                </div>
                            </div>`;
    table.innerHTML += block;
});

connection.on("newUser",
    (data) => {
        var nicknames = document.getElementById("nicknames");
        nicknames.innerHTML += `<option value="${data}"></option>`
    });

function fulfilled() {

}

function rejected() {
    
}

connection.start().then()