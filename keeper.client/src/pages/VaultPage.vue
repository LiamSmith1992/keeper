<template>
  <div class="container">
    <section class="row justify-content-center">
      <div class="col-10 m-2 ">

        <img class="vault-img  " :src="vault.img" alt="">

      </div>
      <div class="text-center"> Keeps:{{ keeps.length }}</div>
    </section>
    <section v-if="keeps" class="row">
      <div v-for="k in keeps" class="col-3 m-2">
        <button v-if="vault.creatorId == account.id" @click="deleteKeep(k.vaultKeepId)" title="Delete Keep"
          class=" ms-1 p-1 btn btn-danger mdi mdi-delete"></button>
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
import Pop from "../utils/Pop";
import { vaultKeepsService } from "../services/VaultKeepsService";
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
      keeps: computed(() => AppState.vaultKeeps),
      account: computed(() => AppState.account),

      async deleteKeep(vaultKeepId) {
        try {

          const yes = await Pop.confirm("are you sure")
          if (!yes) { return }

          await vaultKeepsService.deleteKeep(vaultKeepId)

        } catch (error) {
          logger.error(error.message)
        }
      }


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