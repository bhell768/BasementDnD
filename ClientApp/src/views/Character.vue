<template>
    <v-container fluid grid-list-md>
    <v-layout row wrap>
        <v-flex xs12 sm4>
            <v-card>
                <v-card-text>Logo</v-card-text>
            </v-card>
        </v-flex>
        <v-flex xs12 sm8>
            <v-card>
                <v-card-text>Info</v-card-text>
            </v-card>
        </v-flex>
    </v-layout>
    <v-layout row wrap v-if="phone">
        <v-flex d-flex xs12 order-xs1>
            <v-card>
                <v-card-text>Main Info1</v-card-text>
                <p>Main Info Content</p>
                <p>Main Info Content</p>
                <p>Main Info Content Making it slightly taller</p>
            </v-card>
        </v-flex>
        <v-flex d-flex xs12 order-xs4>
            <v-card>
                <v-card-text>Weapons</v-card-text>
                <p>Tall Info Content</p>
                <p>Tall Info Content</p>
                <p>Tall Info Content</p>
                <p>Tall Info Content</p>
                <p>Tall Info Content</p>
            </v-card>
        </v-flex>
        <v-flex d-flex xs12 order-xs2>
            <v-card>
                <v-card-text>Main Info2</v-card-text>
                <p>Main Info Content</p>
                <p>Main Info Content</p>
            </v-card>
        </v-flex>
        <v-flex d-flex xs12 order-xs3>
            <v-card>
                <v-card-text>Skills</v-card-text>
                <v-container>
                    <skill v-for="(skill, index) in skills" :key="`skill-${skillupdate}-${index}`" :skillIn="skill"></skill>
                </v-container>
            </v-card>
        </v-flex>
    </v-layout>
    <v-layout row v-else>
        <v-flex xs6>     
            <v-layout column wrap>
                <v-flex d-flex xs12>
                    <v-card>
                        <v-card-text>Main Info1</v-card-text>
                        <p>Main Info Content</p>
                        <p>Main Info Content</p>
                        <p>Main Info Content Making it slightly taller</p>
                    </v-card>
                </v-flex>
                <v-flex d-flex xs12>
                    <v-card>
                        <v-card-text>Weapons</v-card-text>
                        <p>Tall Info Content</p>
                        <p>Tall Info Content</p>
                        <p>Tall Info Content</p>
                        <p>Tall Info Content</p>
                        <p>Tall Info Content</p>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-flex>
        <v-flex xs6>
            <v-layout column wrap>
                <v-flex d-flex xs12>
                    <v-card>
                        <v-card-text>Main Info2</v-card-text>
                        <p>Main Info Content</p>
                        <p>Main Info Content</p>
                    </v-card>
                </v-flex>
                <v-flex d-flex xs12>
                    <v-card>
                        <v-card-text>Skills</v-card-text>
                        <v-container>
                            <skill v-for="(skill, index) in skills" :key="`skill-${skillupdate}-${index}`" :skillIn="skill"></skill>
                        </v-container>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-flex>
    </v-layout>
    <h1>Create Character</h1>
        <v-layout row wrap>
        <v-flex xs12 sm8>
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
                untrained: false},
                {skillName: "Disguise",
                skillCode: "DIS",
                abilityModType: "CHA",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Escape Artist",
                skillCode: "ECA",
                abilityModType: "DEX",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Fly",
                skillCode: "FLY",
                abilityModType: "DEX",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Handle Animal",
                skillCode: "HDA",
                abilityModType: "CHA",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Heal",
                skillCode: "HEL",
                abilityModType: "WIS",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Intimidate",
                skillCode: "ITD",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Knowledge (Arcana)",
                skillCode: "KAR",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Knowledge (Dungeoneering)",
                skillCode: "KDG",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Knowledge (Engineering)",
                skillCode: "KEG",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Knowledge (Geography)",
                skillCode: "KGO",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Knowledge (History)",
                skillCode: "KHT",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Knowledge (Local)",
                skillCode: "KLC",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Knowledge (Nature)",
                skillCode: "KNR",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Knowledge (Nobility)",
                skillCode: "KNB",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Knowledge (Planes)",
                skillCode: "KPL",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Knowledge (Religion)",
                skillCode: "KRG",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Linguistics",
                skillCode: "LNG",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Perception",
                skillCode: "PRP",
                abilityModType: "WIS",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Perform",
                skillCode: "PRF",
                abilityModType: "CHA",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Profession",
                skillCode: "PFN",
                abilityModType: "WIS",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Ride",
                skillCode: "RID",
                abilityModType: "DEX",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Sense Motive",
                skillCode: "SMT",
                abilityModType: "WIS",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Slieight of Hand",
                skillCode: "SOH",
                abilityModType: "DEX",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Spellcraft",
                skillCode: "SPC",
                abilityModType: "INT",
                skillRanks: 0,
                miscMod: 0,
                untrained: false},
                {skillName: "Stealth",
                skillCode: "STL",
                abilityModType: "DEX",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Survival",
                skillCode: "SRV",
                abilityModType: "WIS",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Swim",
                skillCode: "SWM",
                abilityModType: "STR",
                skillRanks: 0,
                miscMod: 0,
                untrained: true},
                {skillName: "Use Magic Device",
                skillCode: "UWM",
                abilityModType: "CHA",
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
                isClassSkill: false},
                {skillName: "Disguise",
                skillCode: "DIS",
                isClassSkill: false},
                {skillName: "Escape Artist",
                skillCode: "ECA",
                isClassSkill: false},
                {skillName: "Fly",
                skillCode: "FLY",
                isClassSkill: false},
                {skillName: "Handle Animal",
                skillCode: "HDA",
                isClassSkill: false},
                {skillName: "Heal",
                skillCode: "HEL",
                isClassSkill: false},
                {skillName: "Intimidate",
                skillCode: "ITD",
                isClassSkill: false},
                {skillName: "Knowledge (Arcana)",
                skillCode: "KAR",
                isClassSkill: false},
                {skillName: "Knowledge (Dungeoneering)",
                skillCode: "KDG",
                isClassSkill: false},
                {skillName: "Knowledge (Engineering)",
                skillCode: "KEG",
                isClassSkill: false},
                {skillName: "Knowledge (Geography)",
                skillCode: "KGO",
                isClassSkill: false},
                {skillName: "Knowledge (History)",
                skillCode: "KHT",
                isClassSkill: false},
                {skillName: "Knowledge (Local)",
                skillCode: "KLC",
                isClassSkill: false},
                {skillName: "Knowledge (Nature)",
                skillCode: "KNR",
                isClassSkill: false},
                {skillName: "Knowledge (Nobility)",
                skillCode: "KNB",
                isClassSkill: false},
                {skillName: "Knowledge (Planes)",
                skillCode: "KPL",
                isClassSkill: false},
                {skillName: "Knowledge (Religion)",
                skillCode: "KRG",
                isClassSkill: false},
                {skillName: "Linguistics",
                skillCode: "LNG",
                isClassSkill: false},
                {skillName: "Perception",
                skillCode: "PRP",
                isClassSkill: false},
                {skillName: "Perform",
                skillCode: "PRF",
                isClassSkill: false},
                {skillName: "Profession",
                skillCode: "PFN",
                isClassSkill: false},
                {skillName: "Ride",
                skillCode: "RID",
                isClassSkill: false},
                {skillName: "Sense Motive",
                skillCode: "SMT",
                isClassSkill: false},
                {skillName: "Slieight of Hand",
                skillCode: "SOH",
                isClassSkill: false},
                {skillName: "Spellcraft",
                skillCode: "SPC",
                isClassSkill: false},
                {skillName: "Stealth",
                skillCode: "STL",
                isClassSkill: false},
                {skillName: "Survival",
                skillCode: "SRV",
                isClassSkill: false},
                {skillName: "Swim",
                skillCode: "SWM",
                isClassSkill: false},
                {skillName: "Use Magic Device",
                skillCode: "UWM",
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
        },
        phone: function() {
            return this.$vuetify.breakpoint.xsOnly
        }
    }
};
</script>
<style scoped>
</style>