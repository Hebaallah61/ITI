document.getElementById("getall").onclick = () => {
    fetch('http://localhost:7000/getall')
        .then(response => response.json())
        .then(clients => {
            let table = document.getElementById("clients");
            let html = `
                <table class="table" style="color:white">
                    <thead>
                        <tr class="th">
                            <th>Name</th>
                            <th>Mobile</th>
                            <th>Address</th>
                            <th>Email</th>
                        </tr>
                    </thead>
                    <tbody>`;
                    console.log(clients);
            for (let c of clients) {
                html += `
                    <tr>
                        <td>${c.name}</td>
                        <td>${c.phone}</td>
                        <td>${c.address}</td>
                        <td>${c.email}</td>
                    </tr>
                `;
            }
            html += `</tbody></table>`;
            table.innerHTML = html;
        })
        .catch(error => console.error('Error:', error));
}

