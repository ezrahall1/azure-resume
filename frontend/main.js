window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
})

const functionApiUrl = 'https://getresumecounter25.azurewebsites.net/api/GetResumeCounter?code=sYKxKpT4d80qx_XfcGy8wXU-bxwXjp-hLvVX6BgpGFaPAzFu-tT5tg%3D%3D';
const localFunctionApi = 'http://localhost:7071/api/GetResumeCounter';

const getVisitCount = () => {
    let count = 30;
    fetch(functionApiUrl).then(response => {
        return response.json()
    }).then(response => {
        console.log("Website called function API.");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function (error) {
        console.log(error);
    });
    return count;
}

