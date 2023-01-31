<template>
  <div class="container">
    <section class="row justify-content-center">
      <div class="col-10 m-2 ">

        <img class="vault-img  " :src="vault.img" alt="">

      </div>
    </section>
    <section v-if="keeps" class="row">
      <div v-for="k in keeps" class="col-3 m-2">
        <KeepsCard :keeps="k" />
      </div>
    </section>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { useRoute } from "vue-router";
import { vaultsService } from "../services/VaultsService";
import { logger } from "../utils/Logger";
import KeepsCard from "../components/KeepsCard.vue";
export default {
  setup() {
    onMounted(() => {
      getOneVault()
      getKeepsInVault()
    });
    const route = useRoute();

    async function getOneVault() {
      try {
        await vaultsService.getOneVault(route.params.vaultId);
      }
      catch (error) {
        logger.error(error.message);
      }

    }
    async function getKeepsInVault() {
      await vaultsService.getKeepsInVault(route.params.vaultId);
    }



    return {
      vault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.vaultKeeps)
    };
  },
  components: { KeepsCard }
};
</script>


<style lang="scss" scoped>
.vault-img {
  width: 100%;
  height: 45vh;
  object-fit: cover;

}
</style>