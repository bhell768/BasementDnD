<template>
    <v-layout>
        <h4>{{skill.skillName}}</h4>
        <v-checkbox 
            v-model="skill.isClassSkill" 
            disabled
            :label="`Class Skill`"></v-checkbox>
        <p>{{skill.abilityMod}}</p>
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
            skill: this.skillIn
        }
    },
    computed: {
        totalBonus: function() {
            let classBonus = 0
            if(this.skill.isClassSkill){
                classBonus = 3
            }
            if(!this.skill.unTrained && !this.isTrained){
                return 0
            }
            return this.skill.abMod + this.skill.ranks + classBonus +this.skill.miscMod
        },
        isTrained: function() {
            return (this.skill.ranks > 0)
        }
    }
}
</script>
