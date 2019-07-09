<template>
        <v-layout>
            <h4>{{ability.abilityName}}</h4>
            <v-text-field
                v-model="ability.abilityScore"
                type="text"
                label="Ability Score"
            ></v-text-field>
            <v-text-field
                v-model="abilityMod"
                type="text"
                readonly=true
                label="Ability Modifier"
            ></v-text-field>
        </v-layout>
</template>

<script>
export default {
    name: 'Ability',
    props: {
        abilityIn: Object
    },
    data() {
        return {
            ability: this.abilityIn
        }
    },
    watch: {
        abilityIn: function(val) {
            this.ability = val
        }
    },
    computed: {
        abilityMod: function() {
            return Math.floor((this.ability.abilityScore-10)/2)
        }
    }
};
</script>

<style scoped></style>
