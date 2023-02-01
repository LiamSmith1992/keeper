<template>
  <div v-if="keep" class="component">
    <section class="row ">
      <div class="d-flex justify-content-center bg-dark text-light">
        <p class="m-1">views:{{ keep.views }}</p>
        <P class="m-1">Kept: {{ keep.kept }}</P>
      </div>
    </section>
    <section class="d-flex row">
      <img class="img-height img-fluid col-6" :src="keep.img" alt="">
      <div class="col-6">
        <h1 class="text-center mt-2">{{ keep.name }}</h1>
        <h5 class="p-2">{{ keep.description }}</h5>

        <div>

          <div>

            <form action="">

              <select v-model="refId.vaultId" class="custom-select mr-sm-2" id="inlineFormCustomSelect">
                <option selected>Choose...</option>
                <option v-for="v in accountVaults" :value="v.id">{{ v.name }}</option>
              </select>
              <button @click.prevent="createVaultKeep(refId, keep.id)" class="btn btn-success ms-3">Save</button>
            </form>
            <div>

              <router-link :to="{ name: 'Profile', params: { profileId: keep?.creatorId } }">
                <img class="profile-img" :title="keep.creator?.name" :src="keep.creator?.picture" alt="">
              </router-link>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>

</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop";
import { vaultKeepsService } from "../services/VaultKeepsService"
import { useRoute } from "vue-router";
export default {
  setup() {
    const refId = ref({})
    const route = useRoute()

    return {
      route,
      keep: computed(() => AppState.activeKeep),
      accountVaults: computed(() => AppState.accountVaults),
      activeVault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),
      refId,


      async createVaultKeep(refId, keepId) {
        try {
          const body = {
            vaultId: refId.vaultId,
            keepId: keepId
          }
          await vaultKeepsService.createVaultKeep(body)
          Pop.toast("keep was added", "success")

        } catch (error) {
          logger.error(error.message)
        }
      },


    }
  }

};
</script>


<style lang="scss" scoped>
.img-height {
  height: 55vh;
}
</style>