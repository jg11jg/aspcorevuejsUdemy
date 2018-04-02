<template>
    <div>
        <div>
            <h1>Local Registration</h1>
            <input type="text" class="form-control" v-model="registration.email" />
            <input type="password" class="form-control" v-model="registration.password" />
            <button class="btn btn-primary" @click="Register()" v-bind:disabled="IsLoggedIn">Register</button>
        </div>
        <div>
            <h1>Local Login</h1>
            <input type="text" class="form-control" v-model="login.email" />
            <input type="password" class="form-control" v-model="login.password" />
            <button class="btn btn-primary" @click="Login()" v-bind:disabled="IsLoggedIn">Login</button>
            <button class="btn btn-primary" @click="CallAuthAPI()">Call API</button>
        </div>
        <div>
            <h1>Social Logins</h1>
            <button class="btn btn-primary" @click="TwitterLogin()" v-bind:disabled="IsLoggedIn">Twitter</button>
            <br />
            <br />
            <button class="btn btn-primary" @click="GitHubLogin()" v-bind:disabled="IsLoggedIn">GitHub</button>
        </div>
        <div>
            <h1>Logout</h1>
            <button class="btn btn-primary" @click="Logout()" v-bind:disabled="!IsLoggedIn">Logout</button>
        </div>
        <div>
            <h1>Resend Verification Email</h1>
            <button class="btn btn-primary" @click="ResendEmail()" v-bind:disabled="!IsLoggedIn || EmailVerified" v-bind:title="IsLoggedIn && EmailVerified ? 'Email already verified' : null" >Resend</button>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        data() {
            return {
                registration: {
                    email: null,
                    password: null
                },
                login:
                    {
                        email: null,
                        password: null
                    },
                IsLoggedIn: false,
                EmailVerified: false
            }
        },
        methods: {
            Login: function () {
                this.$http.post('/api/Users/Login', { email: this.login.email, password: this.login.password }).then(result => {
                    this.token = result.data;
                    this.IsLoggedIn = true
                    alert(`You are authenticated, token:${this.token}`);

                }).catch(function(error) {
                    alert("You are an Unauthorized user");
                });
            },
            Register: function () {
                alert(`${this.registration.email}/${this.registration.password}`);
            },
            CallAuthAPI: function () {
                alert(this.IsLoggedIn)
                //var config = axios.create({ headers: { 'Authorization': "Bearer " + this.token } });
                this.$http.get('/api/Users/Test', { headers: { 'Authorization': "Bearer " + this.token } }).then(result => {
                    alert(result.data);
                }).catch(function(error) {
                    alert("You are an Unauthorized user");
                });
            },
            TwitterLogin: function () {
                alert("dsaf")
                alert(this.token)
                alert(this.IsLoggedIn)
                alert(this.token ? true : false)
            },
            Logout: function () {
                this.IsLoggedIn = false;
            },
        }
    }
</script>

<style>

</style>
