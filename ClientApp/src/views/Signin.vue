<template>
    <v-container v-if="info.islogged" fluid>
        <v-layout>
            <h1>Signout Page</h1>
            <h3>Hello {{info.displayname}}</h3>
            <v-btn v-on:click="signOut">Sign Out</v-btn>
        </v-layout>
    </v-container>
    <v-container v-else fluid>
        <v-layout>
            <h1>Signin Page</h1>
            <v-text-field
                v-model="user.username"
                type="text"
                label="Username"
            ></v-text-field>
            <v-text-field
                v-model="user.password"
                type="password"
                label="Password"
            ></v-text-field>
            <v-checkbox
                v-model="user.persistent"
                label="Keep Me Logged In"
            ></v-checkbox>
            <v-btn v-on:click="signIn">Sign In</v-btn>
        </v-layout>
        <v-container fluid>
        <v-layout>
            <h1>SignUp</h1>
            <v-text-field
                v-model="signup.username"
                type="text"
                label="Username"
            ></v-text-field>
            <v-text-field
                v-model="signup.displayname"
                type="text"
                label="Display Name"
            ></v-text-field>
            <v-text-field
                v-model="signup.email"
                type="text"
                label="Email"
            ></v-text-field>
            <v-text-field
                v-model="signup.password"
                type="password"
                label="Password"
            ></v-text-field>
            <v-text-field
                v-model="signup.vPassword"
                type="password"
                label="Verify Password"
            ></v-text-field>
            <v-checkbox
                v-model="user.persistent"
                label="Keep Me Logged In"
            ></v-checkbox>
            <v-btn v-on:click="signUp">SignUp</v-btn>
        </v-layout>
    </v-container>
    </v-container>
</template>
<script>
import Api from '@/components/Api';
export default {
    name: 'Signin',
    data () {
        return {
            info: {
                islogged: false,
                username: "",
                displayname: ""
            },
            logins: null,
            user: {},
            signup: {}
        }      
    },
    methods: {
        async signIn() {
            let response = await Api.post('./api/login/login', this.user)
            console.log(response)
        },
        async signOut(){
            let response = await Api.get('./api/login/logout')
            console.log(response)
        },
        async getInfo() {
            let response = await Api.get('./Api/login/getinfo')
            this.info = response.data
        },
        async signUp(){
            let response = await Api.post('./Api/login/signup', this.signup)
            console.log(response)
        }
    },
    mounted: function () {
        
    },
    created() {
        this.getInfo()
    }
};
</script>
<style scoped>
</style>