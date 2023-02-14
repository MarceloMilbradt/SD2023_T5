const axios = require('axios');

axios.get('https://projetosd-d46bb-default-rtdb.firebaseio.com/t5.json')
    .then(response => {
        console.log(response.data);
    })