

function LogIn() {
    const ID = document.getElementById('inputName');
    const Password = document.getElementById('inputPassword');

    const item = {
        ID: ID.value,
        Password: Password.value
    };

    fetch('v1/Login', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(data => redirectData(data))
        .catch(error => console.log('Erro:', error));
}

function redirectData(data) {
    sessionStorage.setItem('token', data.accessToken);
    window.location.href = "index.html";
}

function getFeriados() {
    const token = sessionStorage.getItem('token');

    fetch('v1/feriado', {
        method: 'GET',
        headers: new Headers({
            'Authorization': 'Bearer ' + token
        })
    })
        .then(response => response.json())
        .then(data => populateFeriados(data))
        .catch(error => console.log('Erro:', error));
}

function populateFeriados(data) {
    let divTable = document.getElementById('tbFeriados');
    let divAlert = document.getElementById('feriadosAlert');

    if (data.length > 0) {
        divTable.style.display = "inline-table";
        divAlert.style.display = "none";

        let tbBody = document.getElementById('tbBody');
        tbBody.innerHTML = '';

        //------------------- Looping Itens List

        let tr;
        let td;
        let values;

        data.forEach(item => {

            tr = document.createElement("TR");
            tr.setAttribute("id", item.feriadoId)

            td = document.createElement("TD");
            values = document.createTextNode(item.feriadoNome);
            td.setAttribute("class", "row-data");
            td.appendChild(values);
            tr.appendChild(td);

            td = document.createElement("TD");
            values = document.createTextNode(formatDate(item.dataFeriado, 'pt-br'));
            td.setAttribute("class", "row-data");
            td.appendChild(values);
            tr.appendChild(td);

            td = document.createElement("TD");
            values = document.createTextNode(item.tipoFeriado.descricao);
            td.setAttribute("class", "row-data");
            td.appendChild(values);
            tr.appendChild(td);

            let btn = document.createElement('button');
            btn.innerHTML = "Editar";
            btn.setAttribute('onclick', 'openModalEdit(' + item.feriadoId + ')');
            btn.setAttribute("class", "btn btn-outline-info");
            tr.appendChild(btn);

            let btnDel = document.createElement('button');
            btnDel.innerHTML = "Excluir";
            btnDel.setAttribute('onclick', 'deleteFeriado(' + item.feriadoId + ')');
            btnDel.setAttribute("class", "btn btn-outline-danger ");
            tr.appendChild(btnDel);

            tbBody.appendChild(tr);

        });
    }
    else {
        divTable.style.display = "none";
        divAlert.style.display = "block";
    }

}

function openModalEdit(feriadoId) {
    limparInputs();
    var data = document.getElementById(feriadoId).querySelectorAll(".row-data");

    document.getElementById('feriadoId').value = feriadoId;
    document.getElementById('feriadoNome').value = data[0].innerHTML;
    document.getElementById('dataFeriado').value = formatDate(data[1].innerHTML, 'en-US');
    var ddl = document.getElementById('tipoFeriado');
    for (var i = 0; i < ddl.options.length; i++) {
        if (ddl.options[i].text === data[2].innerHTML) {
            ddl.selectedIndex = i;
            break;
        }
    }
    document.getElementById('tituloModal').innerHTML = "Editar Feriado";
    $('#exampleModal').modal('show');
}

function optionSave() {
    if (document.getElementById('feriadoId').value == '')
        salvarFeriado();
    else
        editarFeriado();
}

function salvarFeriado() {
    const token = sessionStorage.getItem('token');

    const item = {
        feriadoId: 0,
        feriadoNome: document.getElementById('feriadoNome').value,
        dataFeriado: document.getElementById('dataFeriado').value,
        tipoFeriadoId: document.getElementById('tipoFeriado').value
    };

    fetch('v1/feriado', {
        method: 'POST',
        headers: new Headers({
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(response => this.getFeriados())
        .catch(error => console.log('Erro:', error));

    limparInputs();
    $('#exampleModal').modal('hide');
}

function editarFeriado(feriadoId) {
    const token = sessionStorage.getItem('token');

    const item = {
        feriadoId: document.getElementById('feriadoId').value,
        feriadoNome: document.getElementById('feriadoNome').value,
        dataFeriado: document.getElementById('dataFeriado').value,
        tipoFeriadoId: document.getElementById('tipoFeriado').value
    };

    fetch('v1/feriado', {
        method: 'put',
        headers: new Headers({
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(response => this.getFeriados())
        .catch(error => console.log('Erro:', error));

    limparInputs();
    $('#exampleModal').modal('hide');
}

function deleteFeriado(feriadoId) {
    const token = sessionStorage.getItem('token');

    fetch('v1/feriado/' + feriadoId, {
        method: 'DELETE',
        headers: new Headers({
            'Authorization': 'Bearer ' + token
        })
    })
        .then(response => response.json())
        .then(response => this.getFeriados())
        .catch(error => console.log('Erro:', error));
}

function filtrarFeriados() {
    const token = sessionStorage.getItem('token');

    const mes = document.getElementById('dropdownMes').value;
    const ano = document.getElementById('dropdownAno').value;

    fetch('v1/feriado/GetByMonthYear/' + mes + '/' + ano, {
        method: 'GET',
        headers: new Headers({
            'Authorization': 'Bearer ' + token
        })
    })
        .then(response => response.json())
        .then(data => populateFeriados(data))
        .catch(error => console.log('Erro:', error));
}



function formatDate(data, formato) {
    if (formato == 'pt-br') {
        return (data.substr(0, 10).split('-').reverse().join('/'));
    } else {
        return (data.substr(0, 10).split('/').reverse().join('-'));
    }
}

function limparInputs() {
    document.getElementById('tipoFeriado').value = "0";
    let elements = document.getElementById('feriadoMdl').getElementsByTagName('input');

    for (var i = 0; i < elements.length; i++) {
        elements[i].value = "";
    }
}