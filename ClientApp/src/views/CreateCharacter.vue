<template>
    <v-container fluid>
    <h1>Create Character</h1>
        <v-layout row wrap>
        <v-flex v-if="characterUpdate"xs6>
            <h2>Update Existing Character</h2>
                <div>
                    <v-text-field
                v-model="characterUpdate.name"
                type="text"
                label="Name"
            ></v-text-field>
            <v-text-field
                v-model="characterUpdate.race"
                type="text"
                label="Race"
            ></v-text-field>
            <v-text-field
                v-model="characterUpdate.class"
                type="text"
                label="Class"
            ></v-text-field>
            <v-text-field
                v-model="characterUpdate.description"
                type="text"
                label="Description"
            ></v-text-field>
            <v-btn v-on:click="updateCharacter">Update Character</v-btn>
                </div>
        </v-flex>
        <v-flex v-else xs6>
            <v-text-field
                v-model="characterIn.name"
                type="text"
                label="Name"
            ></v-text-field>
            <v-text-field
                v-model="characterIn.race"
                type="text"
                label="Race"
            ></v-text-field>
            <v-text-field
                v-model="characterIn.class"
                type="text"
                label="Class"
            ></v-text-field>
            <v-text-field
                v-model="characterIn.description"
                type="text"
                label="Description"
            ></v-text-field>
            <v-btn v-on:click="addCharacter">Add Character</v-btn>
        </v-flex>
            

        <v-flex xs6>
        <h2>Current Characters</h2>
            <div v-if="characters">
                <div v-for="character in characters">
                    <h3>Character</h3>
                    <p>Name: {{character.name}}</p>
                    <p>Race: {{character.race}}</p>
                    <p>Class: {{character.class}}</p>
                    <p>Description: {{character.description}}</p>
                    <v-btn v-on:click="selectUpdate(character)">Select</v-btn>
                    <v-btn v-on:click="deleteCharacter(character.id)">Delete</v-btn>
                </div>
            </div>

        </v-flex>
            
        </v-layout>
    </v-container>
</template>
<script>
    import Api from '@/components/Api';
export default {
    name: 'Create Character',
    data () {
        return {
            characters: null,
            characterIn: {},
            characterUpdate: null
        }
    },
    methods: {
        async getCharacters() {
            let reponse = await Api.get('./api/character/get')
            this.characters = reponse.data
            alert(response)
        },
        async addCharacter() {
            let response = await Api.post('./api/character/create', this.characterIn)
            this.characterIn = {}
            this.getCharacters()
        },
        async deleteCharacter(id) {
            let response = await Api.delete('./api/character/delete', {"id": id})
            this.getCharacters()
        },
        async updateCharacter(){
            let response = await Api.post('./api/character/update', this.characterUpdate)
            this.characterUpdate =  null
            this.getCharacters()
        },
        selectUpdate(character){
            this.characterUpdate = character
        }
    },
    mounted: function () {
        this.getCharacters()
    }
};
</script>
<style scoped>
</style>