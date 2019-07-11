<template>
    <v-layout>
        <h4>{{classSkill.skillName}}</h4>
        <v-checkbox 
        v-model="classSkill.isClassSkill" 
        :label="`Class Skill`"></v-checkbox>
    </v-layout>
</template>

<script>
export default {
    name: 'ClassSkill',
    props: {
        classSkillIn: Object
    },
    data() {
        return {
            classSkill: this.classSkillIn
        }
    }
}
</script>

<style scoped></style>
