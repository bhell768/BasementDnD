<template>
    <v-container fluid>
    <h1>Create Character</h1>
        <v-layout row wrap>
        <v-flex xs6>
            <h2 v-if="characterUpdate">Update Existing Character</h2>
            <h2 v-else>Create A New Character</h2>
                <div>
                    <v-text-field
                v-model="characterSelect.name"
                type="text"
                label="Name"
            ></v-text-field>
            <v-text-field
                v-model="characterSelect.race"
                type="text"
                label="Race"
            ></v-text-field>
            <v-text-field
                v-model="characterSelect.class"
                type="text"
                label="Class"
            ></v-text-field>
            <v-text-field
                v-model="characterSelect.hitPoints"
                type="text"
                label="HP"
            ></v-text-field>
            <v-text-field
                v-model="characterSelect.speed"
                type="text"
                label="Speed"
            ></v-text-field>
            <v-text-field
                v-model="characterSelect.armorClass"
                type="text"
                label="AC"
            ></v-text-field>
            <v-text-field
                v-model="characterSelect.description"
                type="text"
                label="Description"
            ></v-text-field>
            <v-container >
                <ability v-for="(ability, index) in characterSelect.abilityScores" :key="`ability-${index}`" :abilityIn="ability"></ability>
            </v-container>
            
                </div>
        </v-flex>
        <v-flex v-if="characterUpdate">
            <v-btn v-on:click="updateCharacter">Update Character</v-btn>
            <v-btn v-on:click="updateCancel">Cancel</v-btn>
        </v-flex>
        <v-flex v-else>
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
                    <v-btn v-if="!characterUpdate" v-on:click="selectUpdate(character)">Select</v-btn>
                    <v-btn v-on:click="deleteCharacter(character.id)">Delete</v-btn>
                </div>
            </div>

        </v-flex>
            
        </v-layout>
    </v-container>
</template>
<script>
    import Api from '@/components/Api';
    import Ability from '@/components/Ability';
export default {
    name: 'CreateCharacter',
    components: {
        Ability
    },
    data() {
        return {
            characters: null,
            characterTemplate: {},
            characterSelect: {},
            characterTemp: {},
            characterUpdate: false,
            abilityTemplate: [
                {abilityName: 'Strength',
                abilityScore: 0,
                abilityMod: 0,
                tempAbilityBool: false,
                tempAbilityScore: 0},
                {abilityName: 'Dexterity',
                abilityScore: 0,
                abilityMod: 0,
                tempAbilityBool: false,
                tempAbilityScore: 0},
                {abilityName: 'Constitution',
                abilityScore: 0,
                abilityMod: 0,
                tempAbilityBool: false,
                tempAbilityScore: 0},
                {abilityName: 'Intelligence',
                abilityScore: 0,
                abilityMod: 0,
                tempAbilityBool: false,
                tempAbilityScore: 0},
                {abilityName: 'Wisdom',
                abilityScore: 0,
                abilityMod: 0,
                tempAbilityBool: false,
                tempAbilityScore: 0},
                {abilityName: 'Charisma',
                abilityScore: 0,
                abilityMod: 0,
                tempAbilityBool: false,
                tempAbilityScore: 0}
            ]
        }
    },
    methods: {
        async getCharacters() {
            let reponse = await Api.get('./api/character/get')
            this.characters = reponse.data
            this.characters.forEach(this.setAbility)
        },
        setAbility(character) {
            if(character.abilityScores == null)
            {
                character.abilityScores = this.abilityTemplate
            }
        },
        async addCharacter() {
            let response = await Api.post('./api/character/create', this.characterSelect)
            this.characterIn = {}
            this.getCharacters()
        },
        async deleteCharacter(id) {
            let response = await Api.delete('./api/character/delete', {"id": id})
            this.getCharacters()
        },
        async updateCharacter(){
            let response = await Api.post('./api/character/update', this.characterSelect)
            this.characterUpdate =  false
            this.characterSelect = this.characterTemplate
            this.getCharacters()
        },
        selectUpdate(character){
            this.characterSelect = character
            this.characterUpdate = true
        },
        updateCancel(){
            this.characterUpdate = false
        }
    },
    mounted: function () {
        this.characterTemplate.abilityScores = this.abilityTemplate
        this.characterSelect = this.characterTemplate
        this.getCharacters()
    }
};
</script>
<style scoped>
</style>