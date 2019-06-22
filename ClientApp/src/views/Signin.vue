<template>
    <v-container fluid>
        <v-layout>
            <h1>Signin Page</h1>
            <v-text-field
                v-model="user.name"
                type="text"
                label="Username"
            ></v-text-field>
            <v-text-field
                v-model="user.password"
                type="password"
                label="Password"
            ></v-text-field>
            <v-btn v-on:click="signIn">Log In</v-btn>
            <v-btn v-on:click="signOut">Sign Out</v-btn>
            <v-btn v-on:click="getInfo">Get Info</v-btn>
        </v-layout>
    </v-container>
</template>
<script>
import Api from '@/components/Api';
export default {
    name: 'Signin',
    data () {
        return {
            logins: null,
            user: {}
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
            console.log(response)
        },
        async createLogin(login){

        }
    },
    mounted: function () {
    }
};
</script>
<style scoped>
</style>