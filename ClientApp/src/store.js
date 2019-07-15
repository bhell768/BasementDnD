import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        demoCounter: 0
    },
    mutations: {
        setDemoCounter(state, payload) {
            state.demoCounter = payload;
        }
    },
    actions: {
        async incrementDemoCounter({ state, commit }) {
            try {
                commit('setDemoCounter', state.demoCounter + 1);
            } catch (error) {
                commit('setDemoCounter', 0);
            }
        }
    }
});
