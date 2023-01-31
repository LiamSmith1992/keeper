<template>
  <div class="container-fluid">



    <section class="row">
      <div class="col-3 m-2 " v-for="k in keeps">
        <KeepsCard :keeps="k" />
      </div>
    </section>


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

</style>
