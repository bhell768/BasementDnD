<template>
</template>

<script>
    import axios from 'axios';
    export default {
        name: 'Api',
        async get(url, params) {
            try {
                let response = await axios.get(url, { params })
                return response
            } catch (err) {
                console.log(err)
            }
        },
        async post(url, data) {
            try {
                let response = await axios.post(url, data)
                return response
            } catch (err) {
                console.log(err)
            }
        },
        async delete(url, params) {
            try {
                let response = await axios.delete(url, { params })
                return response
            } catch (err) {
                console.log(err)
            }
        }
    };
</script>

<style scoped>
</style>