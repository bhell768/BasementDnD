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
        background: url('https://vignette.wikia.nocookie.net/geneitaiyo/images/1/1a/Gears.svg/revision/latest/scale-to-width-down/441?cb=20130814192547');
        background-size: 35% 35%;
        background-repeat: no-repeat;
        background-position: 50% 7%;
        width: 100%;
        height: 100%;
        max-height: 100vh;
    }
</style>
