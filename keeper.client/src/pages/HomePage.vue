<template>
  <div class="container-fluid">

    <body class="masonry-with-columns ">


      <section class="row">


        <div class="col-3 m-2 " v-for="k in keeps">
          <KeepsCard :keeps="k" />
        </div>
        <!-- items -->





      </section>
    </body>

  </div>
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
body {
  margin: 1;
  padding: 1rem;
}

.masonry-with-columns {
  columns: 4 200px;
  column-gap: 2rem;
  column-width: 100%;
  grid-row: unset;
  // column-rule-style: inherit;

  div {
    width: 150px;
    // background: #EC985A;
    // color: white;
    // margin: 0 1rem 1rem 0;
    display: block;
    width: 100%;
    // height: 100%;
    // text-align: ;
    text-justify: bottom;
    font-family: system-ui;
    font-weight: 400;
    font-size: 2rem;


  }



  @for $i from 1 through 36 {
    div:nth-child(#{$i}) {
      $h: (random(400) + 100)+px;
      height: $h;
      line-height: $h;
    }
  }
}
</style>
