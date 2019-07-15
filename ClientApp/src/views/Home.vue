<template>
    <div class="home-hero">
        <span>
            <home-hero></home-hero>
            <home-details></home-details>
        </span>
    </div>
</template>

<script>
import HomeHero from '@/components/HomeHero';
import HomeDetails from '@/components/HomeDetails';

export default {
    name: 'home',
    components: {
        HomeHero,
        HomeDetails
    }
};
</script>

<style scoped>
.home-hero {
    background-size: 35% 35%;
    background-repeat: no-repeat;
    background-position: 50% 7%;
    width: 100%;
    height: 100%;
    max-height: 100vh;
}
</style>
