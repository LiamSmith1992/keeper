<template>
  <div class="about text-center">
    <section class="row cover-img m-2 rounded">
      <div class="col-11 d-flex text-center">


      </div>
    </section>


    <img class="rounded-pill" :src="account.picture" alt="" />
    <h1>{{ account.name }}</h1>
    <p>{{ account.email }}</p>
  </div>
  <p>{{ vaults }}</p>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { useRoute } from "vue-router"
import { accountService } from "../services/AccountService"
import { logger } from "../utils/Logger"
import { vaultsService } from "../services/VaultsService"
import { keepsService } from "../services/KeepsService"
export default {


  setup() {
    onMounted(() => {
      getAccountVaults()
      getAccountKeeps()
    })
    const route = useRoute()

    async function getAccountVaults() {
      try {
        await vaultsService.getAccountVaults()
      } catch (error) {
        logger.error(error.message)
      }
    }

    async function getAccountKeeps() {
      try {

        await keepsService.getProfileKeeps(route.params.id)

      } catch (error) {
        logger.error(error.message)
      }
    }




    return {
      account: computed(() => AppState.account),
      coverImg: computed(() => `url(${AppState.account?.coverImg})`),
      vaults: computed(() => AppState.vaults),

    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}

.cover-img {
  height: 40vh;
  background-image: v-bind(coverImg);
  object-fit: cover;
  width: 1;
  border: solid 3px black;

}
</style>
