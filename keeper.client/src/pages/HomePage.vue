<template>

  <body>

    <div class="masonry-with-columns">






      <KeepsCard v-for="k in keeps" :keeps="k" />



    </div>

  </body>
</template>

<script>
import { onMounted, computed } from "vue";
import { logger } from "../utils/Logger";
import { keepsService } from "../services/KeepsService";
import { AppState } from "../AppState";
import KeepsCard from "../components/KeepsCard.vue";

export default {



  setup() {
    onMounted(() => {
      getKeeps()
    })

    async function getKeeps() {
      try {
        await keepsService.getKeeps()
      } catch (error) {
        logger.error(error.message)
      }
    }




    return {
      keeps: computed(() => AppState.keeps),




    }
  },
  components: { KeepsCard }
}
</script>

<style scoped lang="scss">
// .container {
//   width: 1200px;
//   margin: 0px auto;

// }

// .box {
//   widows: 235px;
//   padding: 20px;
//   border: 1px solid black;
//   float: left;
//   margin: 10px;

// }

// .img {
//   width: 100%;
//   height: 100%;
//   object-fit: contain;

// }








// Result Skip Results Iframe EDIT ON body {
//   margin: 0;
//   padding: 1rem;
// }


// body {
//   margin: 0;
//   padding: 1rem;
// }

.masonry-with-columns {
  columns: 6 200px;
  column-gap: 1rem;

  div {
    width: 150px;
    // background: #EC985A;
    color: white;
    margin: 1rem 1rem 1rem 0;
    display: inline-block;
    width: 100%;
    text-align: center;
    font-family: system-ui;
    // font-weight: 900;
    // font-size: 2rem;
  }

  @for $i from 1 through 36 {
    div:nth-child(#{$i}) {
      $h: (random(400) + 100)+px;
      height: $h;
      line-height: $h;
    }
  }
}



// body {
//   margin: 0;
//   padding: 1rem;
// }

// .masonry-with-columns {
//   columns: 4 200px;
//   column-gap: 20px;

//   div {
//     width: 1200px;
//     // background: #EC985A;
//     // color: white;
//     margin: 0 1rem 1rem 0;
//     display: grid;

//     width: 100%;
//     // text-align: center;
//     // font-family: system-ui;
//     font-weight: 900;
//     font-size: 2rem;
//     // float: none;
//   }


// }






// body {
//   margin: 0;
//   padding: 0;
// }

// .container {
//   width: 1200px;
//   margin: 20px auto;
//   columns: 4;
//   column-gap: 20px;
// }

// .container .box {
//   width: 100%;
//   margin: 0 0 20px;
//   padding: 10px;
//   overflow: hidden;
//   break-inside: avoid;
// }

// .container .box img
// {
//   max-width: 100%;

// }
</style>
