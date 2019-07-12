<template>
        <v-layout>
            <h4>{{ability.abilityName}}</h4>
            <v-text-field
                v-model="ability.abilityScore"
                type="text"
                label="Ability Score"
                mask="##"
                :rules="[rules.min, rules.max]"
                append-icon="add"
                @click:append="increment"
                prepend-inner-icon="remove"
                @click:prepend-inner="decrement"
            ></v-text-field>
            <v-text-field
                v-model="abilityMod"
                type="text"
                readonly
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
            ability: this.abilityIn,
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
