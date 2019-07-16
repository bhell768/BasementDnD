<template>
    <v-container v-if="info.islogged" fluid>
        <v-layout>
            <h1>Sign Out</h1>
            <h3>Hello {{ info.displayname }}</h3>
            <v-btn v-on:click="signOut">Sign Out</v-btn>
        </v-layout>
    </v-container>
    <v-container v-else-if="signin" fluid>
        <v-layout>
            <h1>Sign In</h1>
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
        <v-alert :value="loginerror" type="error"
            >The username or password was incorrect</v-alert
        >
        <v-btn v-on:click="signUpToggle">Sign Up</v-btn>
    </v-container>
    <v-container v-else fluid>
        <v-layout>
            <h1>Sign Up</h1>
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
                v-model="signup.persistent"
                label="Keep Me Logged In"
            ></v-checkbox>
            <v-btn v-on:click="signUp">SignUp</v-btn>
        </v-layout>
        <v-btn v-on:click="signUpToggle">Sign In</v-btn>
    </v-container>
</template>
<script>
import Api from '@/components/Api';
export default {
    name: 'Signin',
    data() {
        return {
            info: {
                islogged: false,
                username: '',
                displayname: ''
            },
            signin: true,
            logins: null,
            user: {},
            signup: {},
            loginerror: false
        };
    },
    methods: {
        async signIn() {
            let response = await Api.post('./api/login/login', this.user);
            if (response.data) {
                this.getInfo();
                this.user = {};
                this.loginerror = false;
            }
            this.loginerror = true;
        },
        async signOut() {
            let response = await Api.get('./api/login/logout');
            if (response.data) {
                this.getInfo();
            }
        },
        async getInfo() {
            let response = await Api.get('./Api/login/getinfo');
            this.info = response.data;
        },
        async signUp() {
            let response = await Api.post('./Api/login/signup', this.signup);
            if (response.data) {
                this.getInfo();
            }
        },
        signUpToggle() {
            this.signin = !this.signin;
        }
    },
    mounted: function() {},
    created() {
        this.getInfo();
    }
};
</script>
<style scoped></style>
