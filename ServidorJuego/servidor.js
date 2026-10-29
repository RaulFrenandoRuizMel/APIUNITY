const http = require("node:http");
const { arch } = require("node:os");
const puerto = 3000;

var archivo = {
    papitas : [
        {
            nombre : "Incógnito",
            precio : 30,
            marca : "Doritos"
        },
        {
            nombre : "Originales",
            precio : 17,
            marca : "Takis"
        },
    ]
}

const server = http.createServer((request, response) => {

    if(request.method = "GET"){
        response.statusCode = 200;
        response.setHeader("Content-Type", "application/json");
        response.end(JSON.stringify(archivo));
    }

        if(request.method = "POST"){
            request.on("data", info =>{
                const nuevas_papitas = JSON.parse(info);
                archivo.papitas.push(nuevas_papitas);

                        response.statusCode = 201;
        response.setHeader("Content-Type", "application/json");
        response.end("Papitas creadas exitosamente");
            })
    }
});

server.listen(puerto, () => {
    console.log("Servidor a la escucha en http://localhost:" + puerto);
});