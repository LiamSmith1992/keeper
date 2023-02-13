<template>
  <div class="container">
    <div v-if="vault">

      <section v-if="keeps" class="row justify-content-center">
        <div class="col-10 m-2 ">

          <img v-if="vault" class="vault-img  " :src="vault.img" alt="">

        </div>
        <div class="text-center"> Keeps:{{ keeps.length }}</div>
      </section>
      <section v-if="keeps" class="row">
        <div v-for="k in keeps" class="col-3 m-2 ">
          <button v-if="vault.creatorId == account.id" @click="deleteKeep(k.vaultKeepId)" title="Delete Keep"
            class="  ms-1 p-1 btn btn-danger mdi mdi-delete"></button>


          <KeepsCard :keeps="k" class="" />

        </div>
      </section>
    </div>
    <div v-else="isPrivate">
      <div class="align-items-center justify-content-center">

        <h1 class="mdi mdi-lock"></h1>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { useRoute } from "vue-router";
import { vaultsService } from "../services/VaultsService";
import { logger } from "../utils/Logger";
import KeepsCard from "../components/KeepsCard.vue";
import Pop from "../utils/Pop";
import { vaultKeepsService } from "../services/VaultKeepsService";
import { router } from "../router";
export default {
  setup() {
    onMounted(() => {
      getOneVault()
      getKeepsInVault()
    });
    const route = useRoute();
    const isPrivate = ref(false)

    async function getOneVault() {
      try {

        await vaultsService.getOneVault(route.params.vaultId);
      }
      catch (error) {
        logger.error(error.message);
        isPrivate.value = true
        setTimeout(() => {
          router.push({ name: 'Home' })
        }, 50)
      }

    }
    async function getKeepsInVault() {
      await vaultsService.getKeepsInVault(route.params.vaultId);
    }



    return {
      vault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.vaultKeeps),
      account: computed(() => AppState.account),
      isPrivate,

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


.delete-btn {
  visibility: hidden;
  opacity: 0;
  transition: ease 2s;
}

.delete-btn-header:hover+.delete-btn {
  visibility: visible;
  opacity: 1;
}
</style>