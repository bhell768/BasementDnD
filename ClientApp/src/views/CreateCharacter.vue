<template>
    <v-container fluid>
        <v-layout>
            <h1>Create Character</h1>
            
            <v-btn v-on:click="getCharacters">Get Characters</v-btn>
            <div v-if="characters">
                <p>{{characters.name}}Hello</p>
                <!--<div v-for="character in characters">
                    <p>{{character.id}}</p>
                    <p>{{character.name}}</p>
                    <p>{{character.race}}</p>-->
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
            characters: {name: "Hello"}
        }
    },
    methods: {
        async getCharacters() {
            let reponse = await Api.get('./api/character/get',{id : '5c8498936de965940d4bfd0b'})
            this.characters = reponse.data
            console.log(characters)
        }
    }
};
</script>
<style scoped>
</style>