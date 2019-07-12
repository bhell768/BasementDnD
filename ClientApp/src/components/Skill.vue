<template>
    <v-layout>
        <h4>{{skill.skillName}}</h4>
        <v-checkbox 
            v-model="skill.isClassSkill" 
            disabled
            :label="`Class Skill`"></v-checkbox>
        <p>{{totalBonus}}</p>
        <p>{{skill.abilityModType}}</p>
        <v-text-field
                v-model="skill.skillRanks"
                type="text"
                label="Ranks"
                mask="##"
                :rules="[rules.min, rules.max]"
                append-icon="add"
                @click:append="increment"
                prepend-inner-icon="remove"
                @click:prepend-inner="decrement"
            ></v-text-field>
    </v-layout>
</template>

<script>
export default {
    name: 'Skill',
    props: {
        skillIn: Object
    },
    data() {
        return {
            skill: this.skillIn,
            rules: {
                min: v => v>=0 || "Value cannot be negative",
                max: v => v <= 20 || "Value cannot be greater than 20"
            }
        }
    },
    methods: {
        increment() {
            this.ability.abilityScore = parseInt(this.ability.abilityScore, 10) + 1
        },
        decrement() {
            this.ability.abilityScore = parseInt(this.ability.abilityScore, 10) - 1
        }
    },
    computed: {
        totalBonus: function() {
            let classBonus = 0
            if(this.skill.isClassSkill && this.isTrained){
                classBonus = 3
            }
            if(!(this.skill.untrained) && !(this.isTrained)){
                return 0
            }
            return Number(this.skill.abilityMod) + Number(this.skill.skillRanks) + classBonus + Number(this.skill.miscMod)
        },
        isTrained: function() {
            return (this.skill.skillRanks > 0)
        }
    }
}
</script>
