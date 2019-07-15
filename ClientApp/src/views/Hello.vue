<template>
    <v-container>
        <h2>Hello</h2>
        <v-text-field
            v-model="name"
            type="text"
            label="Name"
            style="max-width: 15rem;"
        ></v-text-field>
        <div>
            <v-btn v-on:click="clickApi">Click to call API</v-btn>
        </div>
        <div>
            <v-btn v-on:click="clickApiDb"
                >Click to call Api and read the Database for Greeting</v-btn
            >
        </div>
        <div>
            <v-btn v-on:click="clickIncrement"
                >Click to increment counter using Vuex</v-btn
            >
            <v-chip>{{ this.$store.state.demoCounter }}</v-chip>
        </div>
    </v-container>
</template>
<script>
import Api from '@/components/Api';
import store from '@/store';
export default {
    name: 'Hello',
    data() {
        return {
            name: ''
        };
    },
    methods: {
        async clickApi() {
            let response = await Api.post('./api/hello/greetinfo', {
                input: this.name
            });
            alert(response.data.result);
        },
        async clickApiDb() {
            let response = await Api.get('./api/hello/greetinfodb', {
                input: this.name
            });
            alert(response.data.result);
        },
        async clickIncrement() {
            this.$store.dispatch('incrementDemoCounter');
        }
    }
};
</script>
<style scoped></style>
