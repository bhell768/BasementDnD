<template>
    <v-container fluid>
        <v-layout>
            <h1>Signin Page</h1>
            <v-btn v-on:click="getLogins">Get Logins</v-btn>
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
            login: {}
        }      
    },
    methods: {
        async getLogins() {
            let response = await Api.get('./api/login/GetLatest')
            console.log(response)
        },
        async createLogin(login){

        }
    },
    mounted: function () {
        this.getLogins()
    }
};
</script>
<style scoped>
</style>