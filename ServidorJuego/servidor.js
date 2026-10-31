const http = require("node:http");
const { arch } = require("node:os");
const puerto = 3000;

var archivo = {
    papitas: [
        {
            nombre: "Incógnito",
            precio: 30,
            marca: "Doritos"
        },
        {
            nombre: "Originales",
            precio: 17,
            marca: "Takis"
        },
    ]
}

const server = http.createServer((request, response) => {

    response.setHeader("Acces-Control-Allow-Methods", "GET, POST, PUT, DELETE");

    if (request.method == "GET") {
        response.statusCode = 200;
        response.setHeader("Content-Type", "application/json");
        response.end(JSON.stringify(archivo));
    }

    if (request.method = "POST") {
        request.on("data", info => {
            const nuevas_papitas = JSON.parse(info);
            archivo.papitas.push(nuevas_papitas);

            response.statusCode = 201;
            response.setHeader("Content-Type", "application/json");
            response.end("Papitas creadas exitosamente");
        })
    }

    if (request.method = "PUT") {
        request.on("data", info => {
            const papitas_modificadas = JSON.parse(info);
            console.log(papitas_modificadas);

            archivo.papitas[papitas_modificadas.indice] = {
                marca: papitas_modificadas.marca,
                nombre: papitas_modificadas.nombre,
                precio: papitas_modificadas.precio
            }

            response.statusCode = 200;
            response.setHeader("Content-Type", "application/json");
            response.end("papitas creadas");
        });
    }

    if(request.method == "DELETE")
    {
        const indice = request.url.replace("/","")
        archivo.papitas.splice(indice, 1);

        response.statusCode = 200;
        response.setHeader("Content-Type", "application/json");
        response.end("papitas borradas");
    }

    if (request.method == "OPTIONs") {
        response.writeHead(204);
        response.end();
        console.log("lkdkjcjksjñdsjkdjknsd");
    }

});

server.listen(puerto, () => {
    console.log("Servidor a la escucha en http://localhost:" + puerto);
});