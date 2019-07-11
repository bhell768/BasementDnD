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
            <v-expansion-panel>
                <v-expansion-panel-content>
                    <template v-slot:header>
                        <v-text-field
                            v-model="characterSelect.class.className"
                            type="text"
                            label="Class"
                        ></v-text-field>
                    </template>
                    <v-card>
                        <div>
                            <class-skill v-for="(classSkill, index) in characterSelect.class.classSkills" 
                            :key="`cskill-${index}`" 
                            :classSkillIn="classSkill"></class-skill>
                        </div>
                    </v-card>
                </v-expansion-panel-content>
            </v-expansion-panel>
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
            <v-container>
                <skill v-for="(skill, index) in skills" :key="`skill-${skillupdate}-${index}`" :skillIn="skill"></skill>
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
                <div v-for="(character, index) in characters" :key="`character-${index}`">
                    <h3>Character</h3>
                    <p>Name: {{character.name}}</p>
                    <p>Race: {{character.race}}</p>
                    <p>Class: {{character.class.className}}</p>
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
    import ClassSkill from '@/components/ClassSkill';
    import Skill from '@/components/Skill'
export default {
    name: 'Character',
    components: {
        Ability,
        Skill,
        ClassSkill
    },
    data() {
        return {
            skillupdate: 0,
            characters: null,
            characterTemplate: {},
            characterSelect: {},
            characterTemp: {},
            characterUpdate: false,
            abilityTemplate: [
                {abilityName: 'Strength',
                abilityCode: 'STR',
                abilityScore: 0,
                abilityMod: 0,
                tempAbilityBool: false,
                tempAbilityScore: 0},
                {abilityName: 'Dexterity',
                abilityCode: 'DEX',
                abilityScore: 0,
                abilityMod: 0,
                tempAbilityBool: false,
                tempAbilityScore: 0},
                {abilityName: 'Constitution',
                abilityCode: 'CON',
                abilityScore: 0,
                abilityMod: 0,
                tempAbilityBool: false,
                tempAbilityScore: 0},
                {abilityName: 'Intelligence',
                abilityCode: 'INT',
                abilityScore: 0,
                abilityMod: 0,
                tempAbilityBool: false,
                tempAbilityScore: 0},
                {abilityName: 'Wisdom',
                abilityCode: 'WIS',
                abilityScore: 0,
                abilityMod: 0,
                tempAbilityBool: false,
                tempAbilityScore: 0},
                {abilityName: 'Charisma',
                abilityCode: 'CHA',
                abilityScore: 0,
                abilityMod: 0,
                tempAbilityBool: false,
                tempAbilityScore: 0}
            ],
            skillTemplate: [
                {skillName: "Acrobatics",
                skillCode: "ACR",
                abilityModType: "DEX",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Appraise",
                skillCode: "APP",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Bluff",
                skillCode: "BLF",
                abilityModType: "CHA",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Climb",
                skillCode: "CLM",
                abilityModType: "STR",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Craft",
                skillCode: "CRA",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Diplomacy",
                skillCode: "DPM",
                abilityModType: "CHA",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Disable Device",
                skillCode: "DSD",
                abilityModType: "DEX",
                skillRanks: 0,
                miscMod: 0,
                untrained: false}
            ],
            classTemplate: {
                className: ""
            },
            classSkillsTemplate: [
                {skillName: "Acrobatics",
                skillCode: "ACR",
                isClassSkill: false},
                {skillName: "Appraise",
                skillCode: "APP",
                isClassSkill: false},
                {skillName: "Bluff",
                skillCode: "BLF",
                isClassSkill: false},
                {skillName: "Climb",
                skillCode: "CLM",
                isClassSkill: false},
                {skillName: "Craft",
                skillCode: "CRA",
                isClassSkill: false},
                {skillName: "Diplomacy",
                skillCode: "DPM",
                isClassSkill: false},
                {skillName: "Disable Divice",
                skillCode: "DSD",
                isClassSkill: false}
            ]
        }
    },
    methods: {
        async getCharacters() {
            let reponse = await Api.get('./api/character/get')
            this.characters = reponse.data
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
            this.characterSelect = this.characterTemplate
            this.characterUpdate = false
        }
    },
    mounted: function () {
        this.getCharacters()
    },
    created: function () {
        this.characterTemplate.abilityScores = this.abilityTemplate
        this.characterTemplate.skills = this.skillTemplate
        this.characterTemplate.class = this.classTemplate
        this.classTemplate.classSkills = this.classSkillsTemplate
        this.characterSelect = JSON.parse(JSON.stringify(this.characterTemplate))
    },
    computed: {
        skills: function() {
            let i
            let j
            let skills = this.characterSelect.skills
            let tempAbScores = this.characterSelect.abilityScores
            let classSkills = this.characterSelect.class.classSkills
            for(i = 0; i < skills.length; i++) {
                for(j = 0; j < tempAbScores.length; j++){
                    if(tempAbScores[j].abilityCode == skills[i].abilityModType){
                        skills[i].abilityMod = Math.floor((tempAbScores[j].abilityScore-10)/2)
                    }
                }
                skills[i].isClassSkill = classSkills[i].isClassSkill
            }
            //updates skill child component's key which forces a rerender with new data
            if(this.skillupdate == 0){
                this.skillupdate = 1
            }
            else{
                this.skillupdate = 0
            }
            return skills
        }
    }
};
</script>
<style scoped>
</style>