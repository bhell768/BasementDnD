<template>
    <span>
        <!-- drawer start-->
        <v-navigation-drawer
            app
            v-model="drawer"
            class="white"
            light
            disable-resize-watcher
        >
            <v-list>
                <template>
                    <v-list-tile :key="homeItem.title">
                        <router-link :to="homeItem.to">
                            <v-list-tile-content>{{
                                homeItem.title
                            }}</v-list-tile-content>
                        </router-link>
                    </v-list-tile>
                    <v-divider :key="`divider-${homeItem.title}`"></v-divider>
                </template>
                <template v-for="(item, index) in leftItems">
                    <v-list-group :key="`${item.title}-${index}`">
                        <v-list-tile slot="activator">
                            <v-list-tile-content>
                                <v-list-tile-title>{{
                                    item.title
                                }}</v-list-tile-title>
                            </v-list-tile-content>
                        </v-list-tile>
                        <v-list-tile
                            v-for="subItem in item.itemLinks"
                            :key="`${subItem.title}-${index}`"
                            router
                            :to="subItem.to"
                        >
                            <v-list-tile-content>
                                <v-list-tile-title>{{
                                    subItem.itemTitle
                                }}</v-list-tile-title>
                            </v-list-tile-content>
                        </v-list-tile>
                    </v-list-group>
                    <v-divider :key="`divider-${item.title}`"></v-divider>
                </template>
                <template v-for="(item, index) in rightItems">
                    <v-list-tile :key="`${item.title}-${index}`">
                        <router-link :to="item.to">
                            <v-list-tile-content>
                                {{ item.title }}
                            </v-list-tile-content>
                        </router-link>
                    </v-list-tile>
                    <v-divider :key="`divider-${item.title}`"></v-divider>
                </template>
            </v-list>
        </v-navigation-drawer>
        <!-- drawer end -->

        <!-- toolbar start -->
        <v-toolbar app color="white" light>
            <v-toolbar-side-icon
                class="hidden-md-and-up"
                @click="drawer = !drawer"
            ></v-toolbar-side-icon>
            <v-spacer class="hidden-md-and-up"></v-spacer>
            <router-link to="/">
                <v-toolbar-title to="/">{{ homeItem.title }}</v-toolbar-title>
            </router-link>
            <v-menu
                offset-y
                v-for="(item, index) in leftItems"
                v-bind:key="`${item.title}-${index}`"
                class="hidden-sm-and-down"
            >
                <v-btn flat slot="activator">
                    <span>{{ item.title }}</span>
                </v-btn>
                <v-list>
                    <v-list-tile
                        v-for="(link, index) in item.itemLinks"
                        :key="`${link.itemTitle}-${index}`"
                        router
                        :to="link.to"
                    >
                        <v-list-tile-title>{{
                            link.itemTitle
                        }}</v-list-tile-title>
                    </v-list-tile>
                </v-list>
            </v-menu>
            <v-spacer class="hidden-sm-and-down"></v-spacer>
            <v-btn
                flat
                class="hidden-sm-and-down"
                v-for="(item, index) in rightItems"
                :to="item.to"
                v-bind:key="`#${item.title}-${index}`"
                >{{ item.title }}</v-btn
            >
        </v-toolbar>
        <!-- toolbar end -->
    </span>
</template>

<script>
export default {
    name: 'AppNavigation',
    data() {
        return {
            drawer: false,
            homeItem: { title: 'Basement RPG', to: '/' },
            leftItems: [
                {
                    title: 'Character',
                    itemLinks: [{ itemTitle: 'Character', to: 'character' }]
                },
                {
                    title: 'Api Test',
                    itemLinks: [{ itemTitle: 'Test', to: 'hello' }]
                }
            ],
            rightItems: [{ title: 'Sign In', to: 'sign-in' }],
            hotRightItems: []
        };
    },
    computed: {
        items: function() {
            return [this.homeItem]
                .concat(this.leftItems)
                .concat(this.rightItems)
                .concat(this.hotRightItems);
        }
    }
};
</script>

<style scoped>
a {
    color: black;
    text-decoration: none;
}
</style>
