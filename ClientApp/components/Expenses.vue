<template>
    <div>
        <h1>Expenses</h1>

        <p v-if="!expenses"><em>Loading...</em></p>

        <table class="table" v-if="expenses">
            <thead>
                <tr>
                    <th>Amount</th>
                    <th>description</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="expense in expenses" >
                    <td>{{ expense.amount }}</td>
                    <td>{{ expense.description }}</td>
                </tr>
            </tbody>
        </table>
        

    </div>
</template>

<script>
export default {
    data() {
        return {
            expenses: null
        }
    },

    methods: {
    },

    async created() {
        // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
        // TypeScript can also transpile async/await down to ES5
        try {

            var token = localStorage.getItem("token");

            let response = await this.$http.get('https://localhost:44335/api/Expenses', { headers: { 'Authorization': "Bearer " + token } });
                
            console.log(response.data);
            this.expenses = response.data;
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
