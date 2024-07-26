window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
});

const functionApiUrl = 'https://getresumecounter25.azurewebsites.net/api/GetResumeCounter?code=sYKxKpT4d80qx_XfcGy8wXU-bxwXjp-hLvVX6BgpGFaPAzFu-tT5tg%3D%3D';

const getVisitCount = () => {
    fetch(functionApiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            console.log("Website called function API successfully.");
            document.getElementById("counter").innerText = data.count;
        })
        .catch(error => {
            console.log('There was a problem with the fetch operation:', error.message);
            document.getElementById("counter").innerText = "Error loading count";
        });
};
