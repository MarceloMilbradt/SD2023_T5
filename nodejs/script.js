const axios = require('axios');

axios.get('https://projetosd-d46bb-default-rtdb.firebaseio.com/interop.json')
    .then(response => {
        console.log(response.data);
    })