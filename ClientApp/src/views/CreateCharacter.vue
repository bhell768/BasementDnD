<template>
    <v-container fluid>
        <v-layout>
            <h1>Create Character</h1>
            
            <v-btn v-on:click="getCharacters">Get Characters</v-btn>
            <div v-if="characters">
                <div v-for="character in characters">
                    <p>{{character.id}}</p>
                    <p>{{character.name}}</p>
                    <p>{{character.race}}</p>
                </div>
            </div>
        </v-layout>
    </v-container>
</template>
<script>
    import Api from '@/components/Api';
export default {
    name: 'Create Character',
    data () {
        return {
            characters: null
        }
    },
    methods: {
        async getCharacters() {
            let reponse = await Api.get('./api/character',{})
            this.characters = reponse.data.result
            console.log(characters)
        }
    }
};
</script>
<style scoped>
</style>