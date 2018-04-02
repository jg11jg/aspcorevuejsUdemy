<template>
    <div>
        <h1>Expenses</h1>

        <p v-if="!expenses"><em>Loading...</em></p>

        <table class="table" v-if="expenses">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="forecast in forecasts" >
                    <td>{{ forecast.dateFormatted }}</td>
                    <td>{{ forecast.temperatureC }}</td>
                    <td>{{ forecast.temperatureF }}</td>
                    <td>{{ forecast.summary }}</td>
                </tr>
            </tbody>
        </table>
        

    </div>
</template>

<script>
export default {
    data() {
        return {
            forecasts: null
        }
    },

    methods: {
    },

    async created() {
        // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
        // TypeScript can also transpile async/await down to ES5
        try {
            let response = await this.$http.get('https://localhost:44335/api/Expenses', { headers: { 'Authorization': "Bearer " + this.token } });
                
            console.log(response.data);
            this.forecasts = response.data;
        } catch (error) {
            console.log(error)
        }
        // Old promise-based approach
        //this.$http
        //    .get('/api/SampleData/WeatherForecasts')
        //    .then(response => {
        //        console.log(response.data)
        //        this.forecasts = response.data
        //    })
        //    .catch((error) => console.log(error))*/
    }
}
</script>

<style>
</style>
